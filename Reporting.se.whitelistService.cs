public class Reporting.se.whitelistService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""getRepBalance"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getRepByIndex"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""repIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getReporterID"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""index"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""address""}]},{""name"":""getReputation"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int[]""}]},{""name"":""getNumberReporters"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""repIDToIndex"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""repID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getTotalRep"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""hashReport"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""report"",""signature"":""a"",""type"":""bytes32[]""},{""name"":""salt"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";
        private Contract contract;
        public Reporting.se.whitelistService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetGetRepBalanceFunction()
{
   return contract.GetFunction("getRepBalance");
}
public async Task<Int64> GetRepBalanceAsyncCall(Int64  branch,Int64  address)
{
   var function = GetGetRepBalanceFunction();
   return await function.CallAsync<Int64>(branch,address);
}
public async Task<string> GetRepBalanceAsync(string addressFrom, Int64  branch,Int64  address, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetRepBalanceFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,address);
}

public Function GetGetRepByIndexFunction()
{
   return contract.GetFunction("getRepByIndex");
}
public async Task<Int64> GetRepByIndexAsyncCall(Int64  branch,Int64  repIndex)
{
   var function = GetGetRepByIndexFunction();
   return await function.CallAsync<Int64>(branch,repIndex);
}
public async Task<string> GetRepByIndexAsync(string addressFrom, Int64  branch,Int64  repIndex, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetRepByIndexFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,repIndex);
}

public Function GetGetReporterIDFunction()
{
   return contract.GetFunction("getReporterID");
}
public async Task<string> GetReporterIDAsyncCall(Int64  branch,Int64  index)
{
   var function = GetGetReporterIDFunction();
   return await function.CallAsync<string>(branch,index);
}
public async Task<string> GetReporterIDAsync(string addressFrom, Int64  branch,Int64  index, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetReporterIDFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,index);
}

public Function GetGetReputationFunction()
{
   return contract.GetFunction("getReputation");
}
public async Task<Int64[]> GetReputationAsyncCall(Int64  address)
{
   var function = GetGetReputationFunction();
   return await function.CallAsync<Int64[]>(address);
}
public async Task<string> GetReputationAsync(string addressFrom, Int64  address, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetReputationFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, address);
}

public Function GetGetNumberReportersFunction()
{
   return contract.GetFunction("getNumberReporters");
}
public async Task<Int64> GetNumberReportersAsyncCall(Int64  branch)
{
   var function = GetGetNumberReportersFunction();
   return await function.CallAsync<Int64>(branch);
}
public async Task<string> GetNumberReportersAsync(string addressFrom, Int64  branch, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumberReportersFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
}

public Function GetRepIDToIndexFunction()
{
   return contract.GetFunction("repIDToIndex");
}
public async Task<Int64> RepIDToIndexAsyncCall(Int64  branch,Int64  repID)
{
   var function = GetRepIDToIndexFunction();
   return await function.CallAsync<Int64>(branch,repID);
}
public async Task<string> RepIDToIndexAsync(string addressFrom, Int64  branch,Int64  repID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetRepIDToIndexFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,repID);
}

public Function GetGetTotalRepFunction()
{
   return contract.GetFunction("getTotalRep");
}
public async Task<Int64> GetTotalRepAsyncCall(Int64  branch)
{
   var function = GetGetTotalRepFunction();
   return await function.CallAsync<Int64>(branch);
}
public async Task<string> GetTotalRepAsync(string addressFrom, Int64  branch, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetTotalRepFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
}

public Function GetHashReportFunction()
{
   return contract.GetFunction("hashReport");
}
public async Task<> HashReportAsyncCall(byte[][]  report,Int64  salt)
{
   var function = GetHashReportFunction();
   return await function.CallAsync<>(report,salt);
}
public async Task<string> HashReportAsync(string addressFrom, byte[][]  report,Int64  salt, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetHashReportFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, report,salt);
}


}
