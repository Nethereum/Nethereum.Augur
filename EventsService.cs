public class EventsService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""getmode"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getUncaughtOutcome"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMarkets"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getReportingThreshold"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getEventInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getEventBranch"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getExpiration"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getOutcome"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMinValue"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMaxValue"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getNumOutcomes"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""setOutcome"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public EventsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetGetmodeFunction()
{
   return contract.GetFunction("getmode");
}
public async Task<Int64> GetmodeAsyncCall(Int64  event)
{
   var function = GetGetmodeFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetmodeAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetmodeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetUncaughtOutcomeFunction()
{
   return contract.GetFunction("getUncaughtOutcome");
}
public async Task<Int64> GetUncaughtOutcomeAsyncCall(Int64  event)
{
   var function = GetGetUncaughtOutcomeFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetUncaughtOutcomeAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetUncaughtOutcomeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetMarketsFunction()
{
   return contract.GetFunction("getMarkets");
}
public async Task<byte[][]> GetMarketsAsyncCall(Int64  event)
{
   var function = GetGetMarketsFunction();
   return await function.CallAsync<byte[][]>(event);
}
public async Task<string> GetMarketsAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetMarketsFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetReportingThresholdFunction()
{
   return contract.GetFunction("getReportingThreshold");
}
public async Task<Int64> GetReportingThresholdAsyncCall(Int64  event)
{
   var function = GetGetReportingThresholdFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetReportingThresholdAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetReportingThresholdFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetEventInfoFunction()
{
   return contract.GetFunction("getEventInfo");
}
public async Task<byte[][]> GetEventInfoAsyncCall(Int64  event)
{
   var function = GetGetEventInfoFunction();
   return await function.CallAsync<byte[][]>(event);
}
public async Task<string> GetEventInfoAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetEventInfoFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetEventBranchFunction()
{
   return contract.GetFunction("getEventBranch");
}
public async Task<byte[]> GetEventBranchAsyncCall(Int64  event)
{
   var function = GetGetEventBranchFunction();
   return await function.CallAsync<byte[]>(event);
}
public async Task<string> GetEventBranchAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetEventBranchFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetExpirationFunction()
{
   return contract.GetFunction("getExpiration");
}
public async Task<Int64> GetExpirationAsyncCall(Int64  event)
{
   var function = GetGetExpirationFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetExpirationAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetExpirationFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetOutcomeFunction()
{
   return contract.GetFunction("getOutcome");
}
public async Task<Int64> GetOutcomeAsyncCall(Int64  event)
{
   var function = GetGetOutcomeFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetOutcomeAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetOutcomeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetMinValueFunction()
{
   return contract.GetFunction("getMinValue");
}
public async Task<Int64> GetMinValueAsyncCall(Int64  event)
{
   var function = GetGetMinValueFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetMinValueAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetMinValueFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetMaxValueFunction()
{
   return contract.GetFunction("getMaxValue");
}
public async Task<Int64> GetMaxValueAsyncCall(Int64  event)
{
   var function = GetGetMaxValueFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetMaxValueAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetMaxValueFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetGetNumOutcomesFunction()
{
   return contract.GetFunction("getNumOutcomes");
}
public async Task<Int64> GetNumOutcomesAsyncCall(Int64  event)
{
   var function = GetGetNumOutcomesFunction();
   return await function.CallAsync<Int64>(event);
}
public async Task<string> GetNumOutcomesAsync(string addressFrom, Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumOutcomesFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event);
}

public Function GetSetOutcomeFunction()
{
   return contract.GetFunction("setOutcome");
}
public async Task<Int64> SetOutcomeAsyncCall(Int64  ID,Int64  outcome)
{
   var function = GetSetOutcomeFunction();
   return await function.CallAsync<Int64>(ID,outcome);
}
public async Task<string> SetOutcomeAsync(string addressFrom, Int64  ID,Int64  outcome, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSetOutcomeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID,outcome);
}


}
