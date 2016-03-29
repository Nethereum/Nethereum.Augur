using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class CreateMarketService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""createMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""alpha"",""signature"":""i"",""type"":""int""},{""name"":""initialLiquidity"",""signature"":""i"",""type"":""int""},{""name"":""tradingFee"",""signature"":""i"",""type"":""int""},{""name"":""events"",""signature"":""a"",""type"":""bytes32[]""},{""name"":""forkSelection"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";

        private readonly Contract contract;

        public CreateMarketService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetCreateMarketFunction()
        {
            return contract.GetFunction("createMarket");
        }

        public async Task<long> CreateMarketAsyncCall(long branch, string description, long alpha,
            long initialLiquidity, long tradingFee, byte[][] events, long forkSelection)
        {
            var function = GetCreateMarketFunction();
            return
                await
                    function.CallAsync<long>(branch, description, alpha, initialLiquidity, tradingFee, events,
                        forkSelection);
        }

        public async Task<string> CreateMarketAsync(string addressFrom, long branch, string description, long alpha,
            long initialLiquidity, long tradingFee, byte[][] events, long forkSelection, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetCreateMarketFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, description, alpha,
                        initialLiquidity, tradingFee, events, forkSelection);
        }
    }
}