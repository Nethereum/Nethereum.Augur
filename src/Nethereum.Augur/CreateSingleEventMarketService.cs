using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class CreateSingleEventMarketService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""createSingleEventMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""expirationBlock"",""signature"":""i"",""type"":""int""},{""name"":""minValue"",""signature"":""i"",""type"":""int""},{""name"":""maxValue"",""signature"":""i"",""type"":""int""},{""name"":""numOutcomes"",""signature"":""i"",""type"":""int""},{""name"":""alpha"",""signature"":""i"",""type"":""int""},{""name"":""initialLiquidity"",""signature"":""i"",""type"":""int""},{""name"":""tradingFee"",""signature"":""i"",""type"":""int""},{""name"":""forkSelection"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]}]";

        private readonly Contract contract;

        public CreateSingleEventMarketService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetCreateSingleEventMarketFunction()
        {
            return contract.GetFunction("createSingleEventMarket");
        }

        public async Task<byte[]> CreateSingleEventMarketAsyncCall(long branch, string description,
            long expirationBlock, long minValue, long maxValue, long numOutcomes, long alpha,
            long initialLiquidity, long tradingFee, long forkSelection)
        {
            var function = GetCreateSingleEventMarketFunction();
            return
                await
                    function.CallAsync<byte[]>(branch, description, expirationBlock, minValue, maxValue, numOutcomes,
                        alpha, initialLiquidity, tradingFee, forkSelection);
        }

        public async Task<string> CreateSingleEventMarketAsync(string addressFrom, long branch, string description,
            long expirationBlock, long minValue, long maxValue, long numOutcomes, long alpha,
            long initialLiquidity, long tradingFee, long forkSelection, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetCreateSingleEventMarketFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, description, expirationBlock,
                        minValue, maxValue, numOutcomes, alpha, initialLiquidity, tradingFee, forkSelection);
        }
    }
}