public class ExpiringEventsService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""getEventIndex"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""period"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getNumberEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""},{""name"":""eventIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getTotalRepReported"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getReportHash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""},{""name"":""reporter"",""signature"":""i"",""type"":""int""},{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""moveEventsToCurrentPeriod"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""currentVotePeriod"",""signature"":""i"",""type"":""int""},{""name"":""currentPeriod"",""signature"":""i"",""type"":""int""}],""outputs"":[]},{""name"":""addEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""futurePeriod"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[]},{""name"":""setTotalRepReported"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""},{""name"":""repReported"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";
        private Contract contract;
        public ExpiringEventsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetGetEventIndexFunction()
{
   return contract.GetFunction("getEventIndex");
}
public async Task<Int64> GetEventIndexAsyncCall(Int64  period,Int64  eventID)
{
   var function = GetGetEventIndexFunction();
   return await function.CallAsync<Int64>(period,eventID);
}
public async Task<string> GetEventIndexAsync(string addressFrom, Int64  period,Int64  eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetEventIndexFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, period,eventID);
}

public Function GetGetEventsFunction()
{
   return contract.GetFunction("getEvents");
}
public async Task<byte[][]> GetEventsAsyncCall(Int64  branch,Int64  expDateIndex)
{
   var function = GetGetEventsFunction();
   return await function.CallAsync<byte[][]>(branch,expDateIndex);
}
public async Task<string> GetEventsAsync(string addressFrom, Int64  branch,Int64  expDateIndex, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetEventsFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,expDateIndex);
}

public Function GetGetNumberEventsFunction()
{
   return contract.GetFunction("getNumberEvents");
}
public async Task<Int64> GetNumberEventsAsyncCall(Int64  branch,Int64  expDateIndex)
{
   var function = GetGetNumberEventsFunction();
   return await function.CallAsync<Int64>(branch,expDateIndex);
}
public async Task<string> GetNumberEventsAsync(string addressFrom, Int64  branch,Int64  expDateIndex, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumberEventsFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,expDateIndex);
}

public Function GetGetEventFunction()
{
   return contract.GetFunction("getEvent");
}
public async Task<byte[]> GetEventAsyncCall(Int64  branch,Int64  expDateIndex,Int64  eventIndex)
{
   var function = GetGetEventFunction();
   return await function.CallAsync<byte[]>(branch,expDateIndex,eventIndex);
}
public async Task<string> GetEventAsync(string addressFrom, Int64  branch,Int64  expDateIndex,Int64  eventIndex, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetEventFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,expDateIndex,eventIndex);
}

public Function GetGetTotalRepReportedFunction()
{
   return contract.GetFunction("getTotalRepReported");
}
public async Task<Int64> GetTotalRepReportedAsyncCall(Int64  branch,Int64  expDateIndex)
{
   var function = GetGetTotalRepReportedFunction();
   return await function.CallAsync<Int64>(branch,expDateIndex);
}
public async Task<string> GetTotalRepReportedAsync(string addressFrom, Int64  branch,Int64  expDateIndex, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetTotalRepReportedFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,expDateIndex);
}

public Function GetGetReportHashFunction()
{
   return contract.GetFunction("getReportHash");
}
public async Task<byte[]> GetReportHashAsyncCall(Int64  branch,Int64  expDateIndex,Int64  reporter,Int64  event)
{
   var function = GetGetReportHashFunction();
   return await function.CallAsync<byte[]>(branch,expDateIndex,reporter,event);
}
public async Task<string> GetReportHashAsync(string addressFrom, Int64  branch,Int64  expDateIndex,Int64  reporter,Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetReportHashFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,expDateIndex,reporter,event);
}

public Function GetMoveEventsToCurrentPeriodFunction()
{
   return contract.GetFunction("moveEventsToCurrentPeriod");
}
public async Task<> MoveEventsToCurrentPeriodAsyncCall(Int64  branch,Int64  currentVotePeriod,Int64  currentPeriod)
{
   var function = GetMoveEventsToCurrentPeriodFunction();
   return await function.CallAsync<>(branch,currentVotePeriod,currentPeriod);
}
public async Task<string> MoveEventsToCurrentPeriodAsync(string addressFrom, Int64  branch,Int64  currentVotePeriod,Int64  currentPeriod, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetMoveEventsToCurrentPeriodFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,currentVotePeriod,currentPeriod);
}

public Function GetAddEventFunction()
{
   return contract.GetFunction("addEvent");
}
public async Task<> AddEventAsyncCall(Int64  branch,Int64  futurePeriod,Int64  eventID)
{
   var function = GetAddEventFunction();
   return await function.CallAsync<>(branch,futurePeriod,eventID);
}
public async Task<string> AddEventAsync(string addressFrom, Int64  branch,Int64  futurePeriod,Int64  eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetAddEventFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,futurePeriod,eventID);
}

public Function GetSetTotalRepReportedFunction()
{
   return contract.GetFunction("setTotalRepReported");
}
public async Task<> SetTotalRepReportedAsyncCall(Int64  branch,Int64  expDateIndex,Int64  repReported)
{
   var function = GetSetTotalRepReportedFunction();
   return await function.CallAsync<>(branch,expDateIndex,repReported);
}
public async Task<string> SetTotalRepReportedAsync(string addressFrom, Int64  branch,Int64  expDateIndex,Int64  repReported, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSetTotalRepReportedFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,expDateIndex,repReported);
}


}
