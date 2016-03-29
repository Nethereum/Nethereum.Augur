using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class CreateEventService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""createEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""expDate"",""signature"":""i"",""type"":""int""},{""name"":""minValue"",""signature"":""i"",""type"":""int""},{""name"":""maxValue"",""signature"":""i"",""type"":""int""},{""name"":""numOutcomes"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";

        private readonly Contract contract;

        public CreateEventService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetCreateEventFunction()
        {
            return contract.GetFunction("createEvent");
        }

        public async Task<long> CreateEventAsyncCall(long branch, string description, long expDate, long minValue,
            long maxValue, long numOutcomes)
        {
            var function = GetCreateEventFunction();
            return await function.CallAsync<long>(branch, description, expDate, minValue, maxValue, numOutcomes);
        }

        public async Task<string> CreateEventAsync(string addressFrom, long branch, string description, long expDate,
            long minValue, long maxValue, long numOutcomes, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetCreateEventFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, description, expDate, minValue,
                        maxValue, numOutcomes);
        }
    }
}