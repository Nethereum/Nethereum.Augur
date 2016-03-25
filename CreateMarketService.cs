public class CreateMarketService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""createMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""alpha"",""signature"":""i"",""type"":""int""},{""name"":""initialLiquidity"",""signature"":""i"",""type"":""int""},{""name"":""tradingFee"",""signature"":""i"",""type"":""int""},{""name"":""events"",""signature"":""a"",""type"":""bytes32[]""},{""name"":""forkSelection"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";
        private Contract contract;
        public CreateMarketService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetCreateMarketFunction()
{
   return contract.GetFunction("createMarket");
}
public async Task<> CreateMarketAsyncCall(Int64  branch,string  description,Int64  alpha,Int64  initialLiquidity,Int64  tradingFee,byte[][]  events,Int64  forkSelection)
{
   var function = GetCreateMarketFunction();
   return await function.CallAsync<>(branch,description,alpha,initialLiquidity,tradingFee,events,forkSelection);
}
public async Task<string> CreateMarketAsync(string addressFrom, Int64  branch,string  description,Int64  alpha,Int64  initialLiquidity,Int64  tradingFee,byte[][]  events,Int64  forkSelection, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetCreateMarketFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,description,alpha,initialLiquidity,tradingFee,events,forkSelection);
}


}
