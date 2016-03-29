using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class MarketsService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""price"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""lsLmsr"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMarketInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getMarketsInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""offset"",""signature"":""i"",""type"":""int""},{""name"":""numMarketsToLoad"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getMarketEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getNumEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getBranchID"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getCurrentParticipantNumber"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMarketNumOutcomes"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getParticipantSharesPurchased"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""participantNumber"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getSharesPurchased"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getForkSelection"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getVolume"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getWinningOutcomes"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int[]""}]},{""name"":""getParticipantNumber"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getParticipantID"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""participantNumber"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""address""}]},{""name"":""getAlpha"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getCumScale"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getTradingPeriod"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getTradingFee"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initialLiquidityAmount"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""market"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initialLiquiditySetup"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""},{""name"":""alpha"",""signature"":""i"",""type"":""int""},{""name"":""cumScale"",""signature"":""i"",""type"":""int""},{""name"":""numOutcomes"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""modifyShares"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initializeMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""marketID"",""signature"":""i"",""type"":""int""},{""name"":""events"",""signature"":""a"",""type"":""bytes32[]""},{""name"":""tradingPeriod"",""signature"":""i"",""type"":""int""},{""name"":""tradingFee"",""signature"":""i"",""type"":""int""},{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""forkSelection"",""type"":""bytes32""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public MarketsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetPriceFunction()
        {
            return contract.GetFunction("price");
        }

        public async Task<long> PriceAsyncCall(long market, long outcome)
        {
            var function = GetPriceFunction();
            return await function.CallAsync<long>(market, outcome);
        }

        public async Task<string> PriceAsync(string addressFrom, long market, long outcome, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetPriceFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market, outcome);
        }

        public Function GetLsLmsrFunction()
        {
            return contract.GetFunction("lsLmsr");
        }

        public async Task<long> LsLmsrAsyncCall(long marketID)
        {
            var function = GetLsLmsrFunction();
            return await function.CallAsync<long>(marketID);
        }

        public async Task<string> LsLmsrAsync(string addressFrom, long marketID, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetLsLmsrFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID);
        }

        public Function GetGetMarketInfoFunction()
        {
            return contract.GetFunction("getMarketInfo");
        }

        public async Task<byte[][]> GetMarketInfoAsyncCall(long marketID)
        {
            var function = GetGetMarketInfoFunction();
            return await function.CallAsync<byte[][]>(marketID);
        }

        public async Task<string> GetMarketInfoAsync(string addressFrom, long marketID, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMarketInfoFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID);
        }

        public Function GetGetMarketsInfoFunction()
        {
            return contract.GetFunction("getMarketsInfo");
        }

        public async Task<byte[][]> GetMarketsInfoAsyncCall(long branch, long offset, long numMarketsToLoad)
        {
            var function = GetGetMarketsInfoFunction();
            return await function.CallAsync<byte[][]>(branch, offset, numMarketsToLoad);
        }

        public async Task<string> GetMarketsInfoAsync(string addressFrom, long branch, long offset,
            long numMarketsToLoad, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetMarketsInfoFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, offset, numMarketsToLoad);
        }

        public Function GetGetMarketEventsFunction()
        {
            return contract.GetFunction("getMarketEvents");
        }

        public async Task<byte[][]> GetMarketEventsAsyncCall(long market)
        {
            var function = GetGetMarketEventsFunction();
            return await function.CallAsync<byte[][]>(market);
        }

        public async Task<string> GetMarketEventsAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMarketEventsFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetNumEventsFunction()
        {
            return contract.GetFunction("getNumEvents");
        }

        public async Task<long> GetNumEventsAsyncCall(long market)
        {
            var function = GetGetNumEventsFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetNumEventsAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetNumEventsFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetBranchIDFunction()
        {
            return contract.GetFunction("getBranchID");
        }

        public async Task<byte[]> GetBranchIDAsyncCall(long market)
        {
            var function = GetGetBranchIDFunction();
            return await function.CallAsync<byte[]>(market);
        }

        public async Task<string> GetBranchIDAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetBranchIDFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetCurrentParticipantNumberFunction()
        {
            return contract.GetFunction("getCurrentParticipantNumber");
        }

        public async Task<long> GetCurrentParticipantNumberAsyncCall(long market)
        {
            var function = GetGetCurrentParticipantNumberFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetCurrentParticipantNumberAsync(string addressFrom, long market,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetCurrentParticipantNumberFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetMarketNumOutcomesFunction()
        {
            return contract.GetFunction("getMarketNumOutcomes");
        }

        public async Task<long> GetMarketNumOutcomesAsyncCall(long market)
        {
            var function = GetGetMarketNumOutcomesFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetMarketNumOutcomesAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMarketNumOutcomesFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetParticipantSharesPurchasedFunction()
        {
            return contract.GetFunction("getParticipantSharesPurchased");
        }

        public async Task<long> GetParticipantSharesPurchasedAsyncCall(long market, long participantNumber,
            long outcome)
        {
            var function = GetGetParticipantSharesPurchasedFunction();
            return await function.CallAsync<long>(market, participantNumber, outcome);
        }

        public async Task<string> GetParticipantSharesPurchasedAsync(string addressFrom, long market,
            long participantNumber, long outcome, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetParticipantSharesPurchasedFunction();
            return
                await function.SendTransactionAsync(addressFrom, gas, valueAmount, market, participantNumber, outcome);
        }

        public Function GetGetSharesPurchasedFunction()
        {
            return contract.GetFunction("getSharesPurchased");
        }

        public async Task<long> GetSharesPurchasedAsyncCall(long market, long outcome)
        {
            var function = GetGetSharesPurchasedFunction();
            return await function.CallAsync<long>(market, outcome);
        }

        public async Task<string> GetSharesPurchasedAsync(string addressFrom, long market, long outcome,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetSharesPurchasedFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market, outcome);
        }

        public Function GetGetForkSelectionFunction()
        {
            return contract.GetFunction("getForkSelection");
        }

        public async Task<byte[]> GetForkSelectionAsyncCall(long market)
        {
            var function = GetGetForkSelectionFunction();
            return await function.CallAsync<byte[]>(market);
        }

        public async Task<string> GetForkSelectionAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetForkSelectionFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetVolumeFunction()
        {
            return contract.GetFunction("getVolume");
        }

        public async Task<long> GetVolumeAsyncCall(long market)
        {
            var function = GetGetVolumeFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetVolumeAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetVolumeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetWinningOutcomesFunction()
        {
            return contract.GetFunction("getWinningOutcomes");
        }

        public async Task<long[]> GetWinningOutcomesAsyncCall(long market)
        {
            var function = GetGetWinningOutcomesFunction();
            return await function.CallAsync<long[]>(market);
        }

        public async Task<string> GetWinningOutcomesAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetWinningOutcomesFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetParticipantNumberFunction()
        {
            return contract.GetFunction("getParticipantNumber");
        }

        public async Task<long> GetParticipantNumberAsyncCall(long market, long address)
        {
            var function = GetGetParticipantNumberFunction();
            return await function.CallAsync<long>(market, address);
        }

        public async Task<string> GetParticipantNumberAsync(string addressFrom, long market, long address,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetParticipantNumberFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market, address);
        }

        public Function GetGetParticipantIDFunction()
        {
            return contract.GetFunction("getParticipantID");
        }

        public async Task<string> GetParticipantIDAsyncCall(long market, long participantNumber)
        {
            var function = GetGetParticipantIDFunction();
            return await function.CallAsync<string>(market, participantNumber);
        }

        public async Task<string> GetParticipantIDAsync(string addressFrom, long market, long participantNumber,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetParticipantIDFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market, participantNumber);
        }

        public Function GetGetAlphaFunction()
        {
            return contract.GetFunction("getAlpha");
        }

        public async Task<long> GetAlphaAsyncCall(long market)
        {
            var function = GetGetAlphaFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetAlphaAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetAlphaFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetCumScaleFunction()
        {
            return contract.GetFunction("getCumScale");
        }

        public async Task<long> GetCumScaleAsyncCall(long market)
        {
            var function = GetGetCumScaleFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetCumScaleAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetCumScaleFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetTradingPeriodFunction()
        {
            return contract.GetFunction("getTradingPeriod");
        }

        public async Task<long> GetTradingPeriodAsyncCall(long market)
        {
            var function = GetGetTradingPeriodFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetTradingPeriodAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetTradingPeriodFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetGetTradingFeeFunction()
        {
            return contract.GetFunction("getTradingFee");
        }

        public async Task<long> GetTradingFeeAsyncCall(long market)
        {
            var function = GetGetTradingFeeFunction();
            return await function.CallAsync<long>(market);
        }

        public async Task<string> GetTradingFeeAsync(string addressFrom, long market, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetTradingFeeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market);
        }

        public Function GetInitialLiquidityAmountFunction()
        {
            return contract.GetFunction("initialLiquidityAmount");
        }

        public async Task<long> InitialLiquidityAmountAsyncCall(long market, long outcome)
        {
            var function = GetInitialLiquidityAmountFunction();
            return await function.CallAsync<long>(market, outcome);
        }

        public async Task<string> InitialLiquidityAmountAsync(string addressFrom, long market, long outcome,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetInitialLiquidityAmountFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, market, outcome);
        }

        public Function GetInitialLiquiditySetupFunction()
        {
            return contract.GetFunction("initialLiquiditySetup");
        }

        public async Task<long> InitialLiquiditySetupAsyncCall(long marketID, long alpha, long cumScale,
            long numOutcomes)
        {
            var function = GetInitialLiquiditySetupFunction();
            return await function.CallAsync<long>(marketID, alpha, cumScale, numOutcomes);
        }

        public async Task<string> InitialLiquiditySetupAsync(string addressFrom, long marketID, long alpha,
            long cumScale, long numOutcomes, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetInitialLiquiditySetupFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID, alpha, cumScale, numOutcomes);
        }

        public Function GetModifySharesFunction()
        {
            return contract.GetFunction("modifyShares");
        }

        public async Task<long> ModifySharesAsyncCall(long marketID, long outcome, long amount)
        {
            var function = GetModifySharesFunction();
            return await function.CallAsync<long>(marketID, outcome, amount);
        }

        public async Task<string> ModifySharesAsync(string addressFrom, long marketID, long outcome, long amount,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetModifySharesFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID, outcome, amount);
        }

        public Function GetInitializeMarketFunction()
        {
            return contract.GetFunction("initializeMarket");
        }

        public async Task<long> InitializeMarketAsyncCall(long marketID, byte[][] events, long tradingPeriod,
            long tradingFee, long branch, byte[] forkSelection)
        {
            var function = GetInitializeMarketFunction();
            return await function.CallAsync<long>(marketID, events, tradingPeriod, tradingFee, branch, forkSelection);
        }

        public async Task<string> InitializeMarketAsync(string addressFrom, long marketID, byte[][] events,
            long tradingPeriod, long tradingFee, long branch, byte[] forkSelection, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetInitializeMarketFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, marketID, events, tradingPeriod,
                        tradingFee, branch, forkSelection);
        }
    }
}