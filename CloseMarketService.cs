public class CloseMarketService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""closeMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""claimProceeds"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public CloseMarketService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetCloseMarketFunction()
{
   return contract.GetFunction("closeMarket");
}
public async Task<Int64> CloseMarketAsyncCall(Int64  branch,Int64  market)
{
   var function = GetCloseMarketFunction();
   return await function.CallAsync<Int64>(branch,market);
}
public async Task<string> CloseMarketAsync(string addressFrom, Int64  branch,Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetCloseMarketFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,market);
}

public Function GetClaimProceedsFunction()
{
   return contract.GetFunction("claimProceeds");
}
public async Task<Int64> ClaimProceedsAsyncCall(Int64  branch,Int64  market)
{
   var function = GetClaimProceedsFunction();
   return await function.CallAsync<Int64>(branch,market);
}
public async Task<string> ClaimProceedsAsync(string addressFrom, Int64  branch,Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetClaimProceedsFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,market);
}


}
