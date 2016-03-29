using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class BuySellSharesService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""commitTrade"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""hash"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""buyShares"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""},{""name"":""limit"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""sellShares"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""},{""name"":""limit"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public BuySellSharesService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetCommitTradeFunction()
        {
            return contract.GetFunction("commitTrade");
        }

        public async Task<long> CommitTradeAsyncCall(long market, long hash)
        {
            var function = GetCommitTradeFunction();
            return await function.CallAsync<long>(market, hash);
        }

        public async Task<string> CommitTradeAsync(string addressFrom, long market, long hash,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetCommitTradeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market, hash);
        }

        public Function GetBuySharesFunction()
        {
            return contract.GetFunction("buyShares");
        }

        public async Task<long> BuySharesAsyncCall(long branch, long market, long outcome, long amount, long limit)
        {
            var function = GetBuySharesFunction();
            return await function.CallAsync<long>(branch, market, outcome, amount, limit);
        }

        public async Task<string> BuySharesAsync(string addressFrom, long branch, long market, long outcome,
            long amount, long limit, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetBuySharesFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, market, outcome, amount, limit);
        }

        public Function GetSellSharesFunction()
        {
            return contract.GetFunction("sellShares");
        }

        public async Task<long> SellSharesAsyncCall(long branch, long market, long outcome, long amount,
            long limit)
        {
            var function = GetSellSharesFunction();
            return await function.CallAsync<long>(branch, market, outcome, amount, limit);
        }

        public async Task<string> SellSharesAsync(string addressFrom, long branch, long market, long outcome,
            long amount, long limit, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetSellSharesFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, market, outcome, amount, limit);
        }
    }
}