public class OutputService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""sendReputation"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""recver"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public OutputService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetSendReputationFunction()
{
   return contract.GetFunction("sendReputation");
}
public async Task<Int64> SendReputationAsyncCall(Int64  branch,Int64  recver,Int64  value)
{
   var function = GetSendReputationFunction();
   return await function.CallAsync<Int64>(branch,recver,value);
}
public async Task<string> SendReputationAsync(string addressFrom, Int64  branch,Int64  recver,Int64  value, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSendReputationFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,recver,value);
}


}
