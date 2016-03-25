public class CreateEventService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""createEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""expDate"",""signature"":""i"",""type"":""int""},{""name"":""minValue"",""signature"":""i"",""type"":""int""},{""name"":""maxValue"",""signature"":""i"",""type"":""int""},{""name"":""numOutcomes"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";
        private Contract contract;
        public CreateEventService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetCreateEventFunction()
{
   return contract.GetFunction("createEvent");
}
public async Task<> CreateEventAsyncCall(Int64  branch,string  description,Int64  expDate,Int64  minValue,Int64  maxValue,Int64  numOutcomes)
{
   var function = GetCreateEventFunction();
   return await function.CallAsync<>(branch,description,expDate,minValue,maxValue,numOutcomes);
}
public async Task<string> CreateEventAsync(string addressFrom, Int64  branch,string  description,Int64  expDate,Int64  minValue,Int64  maxValue,Int64  numOutcomes, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetCreateEventFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,description,expDate,minValue,maxValue,numOutcomes);
}


}
