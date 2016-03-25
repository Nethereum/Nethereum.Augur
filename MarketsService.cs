public class MarketsService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""price"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""lsLmsr"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMarketInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getMarketsInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""offset"",""signature"":""i"",""type"":""int""},{""name"":""numMarketsToLoad"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getMarketEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getNumEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getBranchID"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getCurrentParticipantNumber"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMarketNumOutcomes"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getParticipantSharesPurchased"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""participantNumber"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getSharesPurchased"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getForkSelection"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getVolume"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getWinningOutcomes"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int[]""}]},{""name"":""getParticipantNumber"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getParticipantID"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""participantNumber"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""address""}]},{""name"":""getAlpha"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getCumScale"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getTradingPeriod"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getTradingFee"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initialLiquidityAmount"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initialLiquiditySetup"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""},{""name"":""alpha"",""signature"":""i"",""type"":""int""},{""name"":""cumScale"",""signature"":""i"",""type"":""int""},{""name"":""numOutcomes"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""modifyShares"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initializeMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""},{""name"":""events"",""signature"":""a"",""type"":""bytes32[]""},{""name"":""tradingPeriod"",""signature"":""i"",""type"":""int""},{""name"":""tradingFee"",""signature"":""i"",""type"":""int""},{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""forkSelection"",""type"":""bytes32""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public MarketsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetPriceFunction()
{
   return contract.GetFunction("price");
}
public async Task<Int64> PriceAsyncCall(Int64  market,Int64  outcome)
{
   var function = GetPriceFunction();
   return await function.CallAsync<Int64>(market,outcome);
}
public async Task<string> PriceAsync(string addressFrom, Int64  market,Int64  outcome, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetPriceFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market,outcome);
}

public Function GetLsLmsrFunction()
{
   return contract.GetFunction("lsLmsr");
}
public async Task<Int64> LsLmsrAsyncCall(Int64  marketID)
{
   var function = GetLsLmsrFunction();
   return await function.CallAsync<Int64>(marketID);
}
public async Task<string> LsLmsrAsync(string addressFrom, Int64  marketID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetLsLmsrFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID);
}

public Function GetGetMarketInfoFunction()
{
   return contract.GetFunction("getMarketInfo");
}
public async Task<byte[][]> GetMarketInfoAsyncCall(Int64  marketID)
{
   var function = GetGetMarketInfoFunction();
   return await function.CallAsync<byte[][]>(marketID);
}
public async Task<string> GetMarketInfoAsync(string addressFrom, Int64  marketID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetMarketInfoFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID);
}

public Function GetGetMarketsInfoFunction()
{
   return contract.GetFunction("getMarketsInfo");
}
public async Task<byte[][]> GetMarketsInfoAsyncCall(Int64  branch,Int64  offset,Int64  numMarketsToLoad)
{
   var function = GetGetMarketsInfoFunction();
   return await function.CallAsync<byte[][]>(branch,offset,numMarketsToLoad);
}
public async Task<string> GetMarketsInfoAsync(string addressFrom, Int64  branch,Int64  offset,Int64  numMarketsToLoad, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetMarketsInfoFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch,offset,numMarketsToLoad);
}

public Function GetGetMarketEventsFunction()
{
   return contract.GetFunction("getMarketEvents");
}
public async Task<byte[][]> GetMarketEventsAsyncCall(Int64  market)
{
   var function = GetGetMarketEventsFunction();
   return await function.CallAsync<byte[][]>(market);
}
public async Task<string> GetMarketEventsAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetMarketEventsFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetNumEventsFunction()
{
   return contract.GetFunction("getNumEvents");
}
public async Task<Int64> GetNumEventsAsyncCall(Int64  market)
{
   var function = GetGetNumEventsFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetNumEventsAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetNumEventsFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetBranchIDFunction()
{
   return contract.GetFunction("getBranchID");
}
public async Task<byte[]> GetBranchIDAsyncCall(Int64  market)
{
   var function = GetGetBranchIDFunction();
   return await function.CallAsync<byte[]>(market);
}
public async Task<string> GetBranchIDAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetBranchIDFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetCurrentParticipantNumberFunction()
{
   return contract.GetFunction("getCurrentParticipantNumber");
}
public async Task<Int64> GetCurrentParticipantNumberAsyncCall(Int64  market)
{
   var function = GetGetCurrentParticipantNumberFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetCurrentParticipantNumberAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetCurrentParticipantNumberFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetMarketNumOutcomesFunction()
{
   return contract.GetFunction("getMarketNumOutcomes");
}
public async Task<Int64> GetMarketNumOutcomesAsyncCall(Int64  market)
{
   var function = GetGetMarketNumOutcomesFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetMarketNumOutcomesAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetMarketNumOutcomesFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetParticipantSharesPurchasedFunction()
{
   return contract.GetFunction("getParticipantSharesPurchased");
}
public async Task<Int64> GetParticipantSharesPurchasedAsyncCall(Int64  market,Int64  participantNumber,Int64  outcome)
{
   var function = GetGetParticipantSharesPurchasedFunction();
   return await function.CallAsync<Int64>(market,participantNumber,outcome);
}
public async Task<string> GetParticipantSharesPurchasedAsync(string addressFrom, Int64  market,Int64  participantNumber,Int64  outcome, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetParticipantSharesPurchasedFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market,participantNumber,outcome);
}

public Function GetGetSharesPurchasedFunction()
{
   return contract.GetFunction("getSharesPurchased");
}
public async Task<Int64> GetSharesPurchasedAsyncCall(Int64  market,Int64  outcome)
{
   var function = GetGetSharesPurchasedFunction();
   return await function.CallAsync<Int64>(market,outcome);
}
public async Task<string> GetSharesPurchasedAsync(string addressFrom, Int64  market,Int64  outcome, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetSharesPurchasedFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market,outcome);
}

public Function GetGetForkSelectionFunction()
{
   return contract.GetFunction("getForkSelection");
}
public async Task<byte[]> GetForkSelectionAsyncCall(Int64  market)
{
   var function = GetGetForkSelectionFunction();
   return await function.CallAsync<byte[]>(market);
}
public async Task<string> GetForkSelectionAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetForkSelectionFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetVolumeFunction()
{
   return contract.GetFunction("getVolume");
}
public async Task<Int64> GetVolumeAsyncCall(Int64  market)
{
   var function = GetGetVolumeFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetVolumeAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetVolumeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetWinningOutcomesFunction()
{
   return contract.GetFunction("getWinningOutcomes");
}
public async Task<Int64[]> GetWinningOutcomesAsyncCall(Int64  market)
{
   var function = GetGetWinningOutcomesFunction();
   return await function.CallAsync<Int64[]>(market);
}
public async Task<string> GetWinningOutcomesAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetWinningOutcomesFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetParticipantNumberFunction()
{
   return contract.GetFunction("getParticipantNumber");
}
public async Task<Int64> GetParticipantNumberAsyncCall(Int64  market,Int64  address)
{
   var function = GetGetParticipantNumberFunction();
   return await function.CallAsync<Int64>(market,address);
}
public async Task<string> GetParticipantNumberAsync(string addressFrom, Int64  market,Int64  address, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetParticipantNumberFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market,address);
}

public Function GetGetParticipantIDFunction()
{
   return contract.GetFunction("getParticipantID");
}
public async Task<string> GetParticipantIDAsyncCall(Int64  market,Int64  participantNumber)
{
   var function = GetGetParticipantIDFunction();
   return await function.CallAsync<string>(market,participantNumber);
}
public async Task<string> GetParticipantIDAsync(string addressFrom, Int64  market,Int64  participantNumber, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetParticipantIDFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market,participantNumber);
}

public Function GetGetAlphaFunction()
{
   return contract.GetFunction("getAlpha");
}
public async Task<Int64> GetAlphaAsyncCall(Int64  market)
{
   var function = GetGetAlphaFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetAlphaAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetAlphaFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetCumScaleFunction()
{
   return contract.GetFunction("getCumScale");
}
public async Task<Int64> GetCumScaleAsyncCall(Int64  market)
{
   var function = GetGetCumScaleFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetCumScaleAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetCumScaleFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetTradingPeriodFunction()
{
   return contract.GetFunction("getTradingPeriod");
}
public async Task<Int64> GetTradingPeriodAsyncCall(Int64  market)
{
   var function = GetGetTradingPeriodFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetTradingPeriodAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetTradingPeriodFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetGetTradingFeeFunction()
{
   return contract.GetFunction("getTradingFee");
}
public async Task<Int64> GetTradingFeeAsyncCall(Int64  market)
{
   var function = GetGetTradingFeeFunction();
   return await function.CallAsync<Int64>(market);
}
public async Task<string> GetTradingFeeAsync(string addressFrom, Int64  market, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetGetTradingFeeFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
}

public Function GetInitialLiquidityAmountFunction()
{
   return contract.GetFunction("initialLiquidityAmount");
}
public async Task<Int64> InitialLiquidityAmountAsyncCall(Int64  market,Int64  outcome)
{
   var function = GetInitialLiquidityAmountFunction();
   return await function.CallAsync<Int64>(market,outcome);
}
public async Task<string> InitialLiquidityAmountAsync(string addressFrom, Int64  market,Int64  outcome, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetInitialLiquidityAmountFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market,outcome);
}

public Function GetInitialLiquiditySetupFunction()
{
   return contract.GetFunction("initialLiquiditySetup");
}
public async Task<Int64> InitialLiquiditySetupAsyncCall(Int64  marketID,Int64  alpha,Int64  cumScale,Int64  numOutcomes)
{
   var function = GetInitialLiquiditySetupFunction();
   return await function.CallAsync<Int64>(marketID,alpha,cumScale,numOutcomes);
}
public async Task<string> InitialLiquiditySetupAsync(string addressFrom, Int64  marketID,Int64  alpha,Int64  cumScale,Int64  numOutcomes, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetInitialLiquiditySetupFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID,alpha,cumScale,numOutcomes);
}

public Function GetModifySharesFunction()
{
   return contract.GetFunction("modifyShares");
}
public async Task<Int64> ModifySharesAsyncCall(Int64  marketID,Int64  outcome,Int64  amount)
{
   var function = GetModifySharesFunction();
   return await function.CallAsync<Int64>(marketID,outcome,amount);
}
public async Task<string> ModifySharesAsync(string addressFrom, Int64  marketID,Int64  outcome,Int64  amount, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetModifySharesFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID,outcome,amount);
}

public Function GetInitializeMarketFunction()
{
   return contract.GetFunction("initializeMarket");
}
public async Task<Int64> InitializeMarketAsyncCall(Int64  marketID,byte[][]  events,Int64  tradingPeriod,Int64  tradingFee,Int64  branch,byte[]  forkSelection)
{
   var function = GetInitializeMarketFunction();
   return await function.CallAsync<Int64>(marketID,events,tradingPeriod,tradingFee,branch,forkSelection);
}
public async Task<string> InitializeMarketAsync(string addressFrom, Int64  marketID,byte[][]  events,Int64  tradingPeriod,Int64  tradingFee,Int64  branch,byte[]  forkSelection, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetInitializeMarketFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID,events,tradingPeriod,tradingFee,branch,forkSelection);
}


}
