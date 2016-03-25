public class Buy&sellSharesService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""commitTrade"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""hash"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""buyShares"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""},{""name"":""limit"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""sellShares"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""},{""name"":""limit"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public Buy&sellSharesService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetCommitTradeFunction()
{
   return contract.GetFunction("commitTrade");
}
public async Task<Int64> CommitTradeAsyncCall(Int64  market,Int64  hash)
{
   var function = GetCommitTradeFunction();
   return await function.CallAsync<Int64>(market,hash);
}
public async Task<string> CommitTradeAsync(string addressFrom, Int64  market,Int64  hash, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetCommitTradeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market,hash);
}

public Function GetBuySharesFunction()
{
   return contract.GetFunction("buyShares");
}
public async Task<Int64> BuySharesAsyncCall(Int64  branch,Int64  market,Int64  outcome,Int64  amount,Int64  limit)
{
   var function = GetBuySharesFunction();
   return await function.CallAsync<Int64>(branch,market,outcome,amount,limit);
}
public async Task<string> BuySharesAsync(string addressFrom, Int64  branch,Int64  market,Int64  outcome,Int64  amount,Int64  limit, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetBuySharesFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,market,outcome,amount,limit);
}

public Function GetSellSharesFunction()
{
   return contract.GetFunction("sellShares");
}
public async Task<Int64> SellSharesAsyncCall(Int64  branch,Int64  market,Int64  outcome,Int64  amount,Int64  limit)
{
   var function = GetSellSharesFunction();
   return await function.CallAsync<Int64>(branch,market,outcome,amount,limit);
}
public async Task<string> SellSharesAsync(string addressFrom, Int64  branch,Int64  market,Int64  outcome,Int64  amount,Int64  limit, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSellSharesFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,market,outcome,amount,limit);
}


}
