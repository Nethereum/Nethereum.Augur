public class MakeReportsService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""getNumEventsToReport"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""votePeriod"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getReportedPeriod"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""period"",""signature"":""i"",""type"":""int""},{""name"":""reporter"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getReportable"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""votePeriod"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getNumReportsActual"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""votePeriod"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getSubmittedHash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""period"",""signature"":""i"",""type"":""int""},{""name"":""reporter"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getBeforeRep"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""period"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getAfterRep"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""period"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getReport"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""period"",""signature"":""i"",""type"":""int""},{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getRRUpToDate"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getNumReportsExpectedEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""votePeriod"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getNumReportsEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""votePeriod"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""makeHash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""salt"",""signature"":""i"",""type"":""int""},{""name"":""report"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""calculateReportingThreshold"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""},{""name"":""votePeriod"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""submitReportHash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""reportHash"",""signature"":""i"",""type"":""int""},{""name"":""votePeriod"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""},{""name"":""eventIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""submitReport"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""votePeriod"",""signature"":""i"",""type"":""int""},{""name"":""eventIndex"",""signature"":""i"",""type"":""int""},{""name"":""salt"",""signature"":""i"",""type"":""int""},{""name"":""report"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""},{""name"":""ethics"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public MakeReportsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetGetNumEventsToReportFunction()
{
   return contract.GetFunction("getNumEventsToReport");
}
public async Task<Int64> GetNumEventsToReportAsyncCall(Int64  branch,Int64  votePeriod)
{
   var function = GetGetNumEventsToReportFunction();
   return await function.CallAsync<Int64>(branch,votePeriod);
}
public async Task<string> GetNumEventsToReportAsync(string addressFrom, Int64  branch,Int64  votePeriod, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumEventsToReportFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,votePeriod);
}

public Function GetGetReportedPeriodFunction()
{
   return contract.GetFunction("getReportedPeriod");
}
public async Task<Int64> GetReportedPeriodAsyncCall(Int64  branch,Int64  period,Int64  reporter)
{
   var function = GetGetReportedPeriodFunction();
   return await function.CallAsync<Int64>(branch,period,reporter);
}
public async Task<string> GetReportedPeriodAsync(string addressFrom, Int64  branch,Int64  period,Int64  reporter, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetReportedPeriodFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,period,reporter);
}

public Function GetGetReportableFunction()
{
   return contract.GetFunction("getReportable");
}
public async Task<Int64> GetReportableAsyncCall(Int64  votePeriod,Int64  eventID)
{
   var function = GetGetReportableFunction();
   return await function.CallAsync<Int64>(votePeriod,eventID);
}
public async Task<string> GetReportableAsync(string addressFrom, Int64  votePeriod,Int64  eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetReportableFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, votePeriod,eventID);
}

public Function GetGetNumReportsActualFunction()
{
   return contract.GetFunction("getNumReportsActual");
}
public async Task<Int64> GetNumReportsActualAsyncCall(Int64  branch,Int64  votePeriod)
{
   var function = GetGetNumReportsActualFunction();
   return await function.CallAsync<Int64>(branch,votePeriod);
}
public async Task<string> GetNumReportsActualAsync(string addressFrom, Int64  branch,Int64  votePeriod, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumReportsActualFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,votePeriod);
}

public Function GetGetSubmittedHashFunction()
{
   return contract.GetFunction("getSubmittedHash");
}
public async Task<byte[]> GetSubmittedHashAsyncCall(Int64  branch,Int64  period,Int64  reporter)
{
   var function = GetGetSubmittedHashFunction();
   return await function.CallAsync<byte[]>(branch,period,reporter);
}
public async Task<string> GetSubmittedHashAsync(string addressFrom, Int64  branch,Int64  period,Int64  reporter, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetSubmittedHashFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,period,reporter);
}

public Function GetGetBeforeRepFunction()
{
   return contract.GetFunction("getBeforeRep");
}
public async Task<Int64> GetBeforeRepAsyncCall(Int64  branch,Int64  period)
{
   var function = GetGetBeforeRepFunction();
   return await function.CallAsync<Int64>(branch,period);
}
public async Task<string> GetBeforeRepAsync(string addressFrom, Int64  branch,Int64  period, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetBeforeRepFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,period);
}

public Function GetGetAfterRepFunction()
{
   return contract.GetFunction("getAfterRep");
}
public async Task<Int64> GetAfterRepAsyncCall(Int64  branch,Int64  period)
{
   var function = GetGetAfterRepFunction();
   return await function.CallAsync<Int64>(branch,period);
}
public async Task<string> GetAfterRepAsync(string addressFrom, Int64  branch,Int64  period, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetAfterRepFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,period);
}

public Function GetGetReportFunction()
{
   return contract.GetFunction("getReport");
}
public async Task<Int64> GetReportAsyncCall(Int64  branch,Int64  period,Int64  event)
{
   var function = GetGetReportFunction();
   return await function.CallAsync<Int64>(branch,period,event);
}
public async Task<string> GetReportAsync(string addressFrom, Int64  branch,Int64  period,Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetReportFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,period,event);
}

public Function GetGetRRUpToDateFunction()
{
   return contract.GetFunction("getRRUpToDate");
}
public async Task<Int64> GetRRUpToDateAsyncCall()
{
   var function = GetGetRRUpToDateFunction();
   return await function.CallAsync<Int64>();
}
public async Task<string> GetRRUpToDateAsync(string addressFrom,  HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetRRUpToDateFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, );
}

public Function GetGetNumReportsExpectedEventFunction()
{
   return contract.GetFunction("getNumReportsExpectedEvent");
}
public async Task<byte[]> GetNumReportsExpectedEventAsyncCall(Int64  branch,Int64  votePeriod,Int64  eventID)
{
   var function = GetGetNumReportsExpectedEventFunction();
   return await function.CallAsync<byte[]>(branch,votePeriod,eventID);
}
public async Task<string> GetNumReportsExpectedEventAsync(string addressFrom, Int64  branch,Int64  votePeriod,Int64  eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumReportsExpectedEventFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,votePeriod,eventID);
}

public Function GetGetNumReportsEventFunction()
{
   return contract.GetFunction("getNumReportsEvent");
}
public async Task<byte[]> GetNumReportsEventAsyncCall(Int64  branch,Int64  votePeriod,Int64  eventID)
{
   var function = GetGetNumReportsEventFunction();
   return await function.CallAsync<byte[]>(branch,votePeriod,eventID);
}
public async Task<string> GetNumReportsEventAsync(string addressFrom, Int64  branch,Int64  votePeriod,Int64  eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumReportsEventFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,votePeriod,eventID);
}

public Function GetMakeHashFunction()
{
   return contract.GetFunction("makeHash");
}
public async Task<byte[]> MakeHashAsyncCall(Int64  salt,Int64  report,Int64  eventID)
{
   var function = GetMakeHashFunction();
   return await function.CallAsync<byte[]>(salt,report,eventID);
}
public async Task<string> MakeHashAsync(string addressFrom, Int64  salt,Int64  report,Int64  eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetMakeHashFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, salt,report,eventID);
}

public Function GetCalculateReportingThresholdFunction()
{
   return contract.GetFunction("calculateReportingThreshold");
}
public async Task<byte[]> CalculateReportingThresholdAsyncCall(Int64  branch,Int64  eventID,Int64  votePeriod)
{
   var function = GetCalculateReportingThresholdFunction();
   return await function.CallAsync<byte[]>(branch,eventID,votePeriod);
}
public async Task<string> CalculateReportingThresholdAsync(string addressFrom, Int64  branch,Int64  eventID,Int64  votePeriod, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetCalculateReportingThresholdFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,eventID,votePeriod);
}

public Function GetSubmitReportHashFunction()
{
   return contract.GetFunction("submitReportHash");
}
public async Task<Int64> SubmitReportHashAsyncCall(Int64  branch,Int64  reportHash,Int64  votePeriod,Int64  eventID,Int64  eventIndex)
{
   var function = GetSubmitReportHashFunction();
   return await function.CallAsync<Int64>(branch,reportHash,votePeriod,eventID,eventIndex);
}
public async Task<string> SubmitReportHashAsync(string addressFrom, Int64  branch,Int64  reportHash,Int64  votePeriod,Int64  eventID,Int64  eventIndex, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSubmitReportHashFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,reportHash,votePeriod,eventID,eventIndex);
}

public Function GetSubmitReportFunction()
{
   return contract.GetFunction("submitReport");
}
public async Task<Int64> SubmitReportAsyncCall(Int64  branch,Int64  votePeriod,Int64  eventIndex,Int64  salt,Int64  report,Int64  eventID,Int64  ethics)
{
   var function = GetSubmitReportFunction();
   return await function.CallAsync<Int64>(branch,votePeriod,eventIndex,salt,report,eventID,ethics);
}
public async Task<string> SubmitReportAsync(string addressFrom, Int64  branch,Int64  votePeriod,Int64  eventIndex,Int64  salt,Int64  report,Int64  eventID,Int64  ethics, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSubmitReportFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,votePeriod,eventIndex,salt,report,eventID,ethics);
}


}
