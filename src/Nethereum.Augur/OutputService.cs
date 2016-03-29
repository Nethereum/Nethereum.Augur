using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class OutputService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""sendReputation"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""recver"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public OutputService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetSendReputationFunction()
        {
            return contract.GetFunction("sendReputation");
        }

        public async Task<long> SendReputationAsyncCall(long branch, long recver, long value)
        {
            var function = GetSendReputationFunction();
            return await function.CallAsync<long>(branch, recver, value);
        }

        public async Task<string> SendReputationAsync(string addressFrom, long branch, long recver, long value,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetSendReputationFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, recver, value);
        }
    }
}