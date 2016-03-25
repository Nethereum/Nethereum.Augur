public class CreateSingleEventMarketService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""createSingleEventMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""expirationBlock"",""signature"":""i"",""type"":""int""},{""name"":""minValue"",""signature"":""i"",""type"":""int""},{""name"":""maxValue"",""signature"":""i"",""type"":""int""},{""name"":""numOutcomes"",""signature"":""i"",""type"":""int""},{""name"":""alpha"",""signature"":""i"",""type"":""int""},{""name"":""initialLiquidity"",""signature"":""i"",""type"":""int""},{""name"":""tradingFee"",""signature"":""i"",""type"":""int""},{""name"":""forkSelection"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]}]";
        private Contract contract;
        public CreateSingleEventMarketService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetCreateSingleEventMarketFunction()
{
   return contract.GetFunction("createSingleEventMarket");
}
public async Task<byte[]> CreateSingleEventMarketAsyncCall(Int64  branch,string  description,Int64  expirationBlock,Int64  minValue,Int64  maxValue,Int64  numOutcomes,Int64  alpha,Int64  initialLiquidity,Int64  tradingFee,Int64  forkSelection)
{
   var function = GetCreateSingleEventMarketFunction();
   return await function.CallAsync<byte[]>(branch,description,expirationBlock,minValue,maxValue,numOutcomes,alpha,initialLiquidity,tradingFee,forkSelection);
}
public async Task<string> CreateSingleEventMarketAsync(string addressFrom, Int64  branch,string  description,Int64  expirationBlock,Int64  minValue,Int64  maxValue,Int64  numOutcomes,Int64  alpha,Int64  initialLiquidity,Int64  tradingFee,Int64  forkSelection, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetCreateSingleEventMarketFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,description,expirationBlock,minValue,maxValue,numOutcomes,alpha,initialLiquidity,tradingFee,forkSelection);
}


}
