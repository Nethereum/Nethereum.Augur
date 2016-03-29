using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class CloseMarketService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""closeMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""claimProceeds"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public CloseMarketService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetCloseMarketFunction()
        {
            return contract.GetFunction("closeMarket");
        }

        public async Task<long> CloseMarketAsyncCall(long branch, long market)
        {
            var function = GetCloseMarketFunction();
            return await function.CallAsync<long>(branch, market);
        }

        public async Task<string> CloseMarketAsync(string addressFrom, long branch, long market,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetCloseMarketFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, market);
        }

        public Function GetClaimProceedsFunction()
        {
            return contract.GetFunction("claimProceeds");
        }

        public async Task<long> ClaimProceedsAsyncCall(long branch, long market)
        {
            var function = GetClaimProceedsFunction();
            return await function.CallAsync<long>(branch, market);
        }

        public async Task<string> ClaimProceedsAsync(string addressFrom, long branch, long market,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetClaimProceedsFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, market);
        }
    }
}