public class InfoService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""getCreator"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""address""}]},{""name"":""getCreationFee"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getDescription"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""setInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""creator"",""signature"":""i"",""type"":""int""},{""name"":""fee"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public InfoService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetGetCreatorFunction()
{
   return contract.GetFunction("getCreator");
}
public async Task<string> GetCreatorAsyncCall(Int64  ID)
{
   var function = GetGetCreatorFunction();
   return await function.CallAsync<string>(ID);
}
public async Task<string> GetCreatorAsync(string addressFrom, Int64  ID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetCreatorFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID);
}

public Function GetGetCreationFeeFunction()
{
   return contract.GetFunction("getCreationFee");
}
public async Task<Int64> GetCreationFeeAsyncCall(Int64  ID)
{
   var function = GetGetCreationFeeFunction();
   return await function.CallAsync<Int64>(ID);
}
public async Task<string> GetCreationFeeAsync(string addressFrom, Int64  ID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetCreationFeeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID);
}

public Function GetGetDescriptionFunction()
{
   return contract.GetFunction("getDescription");
}
public async Task<byte[]> GetDescriptionAsyncCall(Int64  ID)
{
   var function = GetGetDescriptionFunction();
   return await function.CallAsync<byte[]>(ID);
}
public async Task<string> GetDescriptionAsync(string addressFrom, Int64  ID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetDescriptionFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID);
}

public Function GetSetInfoFunction()
{
   return contract.GetFunction("setInfo");
}
public async Task<Int64> SetInfoAsyncCall(Int64  ID,string  description,Int64  creator,Int64  fee)
{
   var function = GetSetInfoFunction();
   return await function.CallAsync<Int64>(ID,description,creator,fee);
}
public async Task<string> SetInfoAsync(string addressFrom, Int64  ID,string  description,Int64  creator,Int64  fee, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSetInfoFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID,description,creator,fee);
}


}
