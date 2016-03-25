public class ConsensusService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""proportionCorrect"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""event"",""signature"":""i"",""type"":""int""},{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""period"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""incrementPeriodAfterReporting"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""penalizeNotEnoughReports"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""collectFees"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""penalizeWrong"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""event"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""penalizationCatchup"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""slashRep"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""salt"",""signature"":""i"",""type"":""int""},{""name"":""report"",""signature"":""i"",""type"":""int""},{""name"":""reporter"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public ConsensusService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetProportionCorrectFunction()
{
   return contract.GetFunction("proportionCorrect");
}
public async Task<Int64> ProportionCorrectAsyncCall(Int64  event,Int64  branch,Int64  period)
{
   var function = GetProportionCorrectFunction();
   return await function.CallAsync<Int64>(event,branch,period);
}
public async Task<string> ProportionCorrectAsync(string addressFrom, Int64  event,Int64  branch,Int64  period, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetProportionCorrectFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, event,branch,period);
}

public Function GetIncrementPeriodAfterReportingFunction()
{
   return contract.GetFunction("incrementPeriodAfterReporting");
}
public async Task<Int64> IncrementPeriodAfterReportingAsyncCall(Int64  branch)
{
   var function = GetIncrementPeriodAfterReportingFunction();
   return await function.CallAsync<Int64>(branch);
}
public async Task<string> IncrementPeriodAfterReportingAsync(string addressFrom, Int64  branch, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetIncrementPeriodAfterReportingFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
}

public Function GetPenalizeNotEnoughReportsFunction()
{
   return contract.GetFunction("penalizeNotEnoughReports");
}
public async Task<Int64> PenalizeNotEnoughReportsAsyncCall(Int64  branch)
{
   var function = GetPenalizeNotEnoughReportsFunction();
   return await function.CallAsync<Int64>(branch);
}
public async Task<string> PenalizeNotEnoughReportsAsync(string addressFrom, Int64  branch, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetPenalizeNotEnoughReportsFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
}

public Function GetCollectFeesFunction()
{
   return contract.GetFunction("collectFees");
}
public async Task<Int64> CollectFeesAsyncCall(Int64  branch)
{
   var function = GetCollectFeesFunction();
   return await function.CallAsync<Int64>(branch);
}
public async Task<string> CollectFeesAsync(string addressFrom, Int64  branch, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetCollectFeesFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
}

public Function GetPenalizeWrongFunction()
{
   return contract.GetFunction("penalizeWrong");
}
public async Task<Int64> PenalizeWrongAsyncCall(Int64  branch,Int64  event)
{
   var function = GetPenalizeWrongFunction();
   return await function.CallAsync<Int64>(branch,event);
}
public async Task<string> PenalizeWrongAsync(string addressFrom, Int64  branch,Int64  event, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetPenalizeWrongFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,event);
}

public Function GetPenalizationCatchupFunction()
{
   return contract.GetFunction("penalizationCatchup");
}
public async Task<Int64> PenalizationCatchupAsyncCall(Int64  branch)
{
   var function = GetPenalizationCatchupFunction();
   return await function.CallAsync<Int64>(branch);
}
public async Task<string> PenalizationCatchupAsync(string addressFrom, Int64  branch, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetPenalizationCatchupFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
}

public Function GetSlashRepFunction()
{
   return contract.GetFunction("slashRep");
}
public async Task<Int64> SlashRepAsyncCall(Int64  branch,Int64  salt,Int64  report,Int64  reporter,Int64  eventID)
{
   var function = GetSlashRepFunction();
   return await function.CallAsync<Int64>(branch,salt,report,reporter,eventID);
}
public async Task<string> SlashRepAsync(string addressFrom, Int64  branch,Int64  salt,Int64  report,Int64  reporter,Int64  eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSlashRepFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,salt,report,reporter,eventID);
}


}
