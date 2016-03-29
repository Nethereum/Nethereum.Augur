using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class CreateBranchService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""createSubbranch"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""periodLength"",""signature"":""i"",""type"":""int""},{""name"":""parent"",""signature"":""i"",""type"":""int""},{""name"":""tradingFee"",""signature"":""i"",""type"":""int""},{""name"":""oracleOnly"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]}]";

        private readonly Contract contract;

        public CreateBranchService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetCreateSubbranchFunction()
        {
            return contract.GetFunction("createSubbranch");
        }

        public async Task<byte[]> CreateSubbranchAsyncCall(string description, long periodLength, long parent,
            long tradingFee, long oracleOnly)
        {
            var function = GetCreateSubbranchFunction();
            return await function.CallAsync<byte[]>(description, periodLength, parent, tradingFee, oracleOnly);
        }

        public async Task<string> CreateSubbranchAsync(string addressFrom, string description, long periodLength,
            long parent, long tradingFee, long oracleOnly, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetCreateSubbranchFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, description, periodLength, parent,
                        tradingFee, oracleOnly);
        }
    }
}