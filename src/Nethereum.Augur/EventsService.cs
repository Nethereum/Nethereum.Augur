using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class EventsService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""getmode"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getUncaughtOutcome"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMarkets"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getReportingThreshold"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getEventInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getEventBranch"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getExpiration"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getOutcome"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMinValue"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMaxValue"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getNumOutcomes"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""setOutcome"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""},{""name"":""outcome"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public EventsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetGetmodeFunction()
        {
            return contract.GetFunction("getmode");
        }

        public async Task<long> GetmodeAsyncCall(long augEvent)
        {
            var function = GetGetmodeFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetmodeAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetmodeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetUncaughtOutcomeFunction()
        {
            return contract.GetFunction("getUncaughtOutcome");
        }

        public async Task<long> GetUncaughtOutcomeAsyncCall(long augEvent)
        {
            var function = GetGetUncaughtOutcomeFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetUncaughtOutcomeAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetUncaughtOutcomeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetMarketsFunction()
        {
            return contract.GetFunction("getMarkets");
        }

        public async Task<byte[][]> GetMarketsAsyncCall(long augEvent)
        {
            var function = GetGetMarketsFunction();
            return await function.CallAsync<byte[][]>(augEvent);
        }

        public async Task<string> GetMarketsAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMarketsFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetReportingThresholdFunction()
        {
            return contract.GetFunction("getReportingThreshold");
        }

        public async Task<long> GetReportingThresholdAsyncCall(long augEvent)
        {
            var function = GetGetReportingThresholdFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetReportingThresholdAsync(string addressFrom, long augEvent,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetReportingThresholdFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetEventInfoFunction()
        {
            return contract.GetFunction("getEventInfo");
        }

        public async Task<byte[][]> GetEventInfoAsyncCall(long augEvent)
        {
            var function = GetGetEventInfoFunction();
            return await function.CallAsync<byte[][]>(augEvent);
        }

        public async Task<string> GetEventInfoAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetEventInfoFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetEventBranchFunction()
        {
            return contract.GetFunction("getEventBranch");
        }

        public async Task<byte[]> GetEventBranchAsyncCall(long augEvent)
        {
            var function = GetGetEventBranchFunction();
            return await function.CallAsync<byte[]>(augEvent);
        }

        public async Task<string> GetEventBranchAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetEventBranchFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetExpirationFunction()
        {
            return contract.GetFunction("getExpiration");
        }

        public async Task<long> GetExpirationAsyncCall(long augEvent)
        {
            var function = GetGetExpirationFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetExpirationAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetExpirationFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetOutcomeFunction()
        {
            return contract.GetFunction("getOutcome");
        }

        public async Task<long> GetOutcomeAsyncCall(long augEvent)
        {
            var function = GetGetOutcomeFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetOutcomeAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetOutcomeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetMinValueFunction()
        {
            return contract.GetFunction("getMinValue");
        }

        public async Task<long> GetMinValueAsyncCall(long augEvent)
        {
            var function = GetGetMinValueFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetMinValueAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMinValueFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetMaxValueFunction()
        {
            return contract.GetFunction("getMaxValue");
        }

        public async Task<long> GetMaxValueAsyncCall(long augEvent)
        {
            var function = GetGetMaxValueFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetMaxValueAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMaxValueFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetGetNumOutcomesFunction()
        {
            return contract.GetFunction("getNumOutcomes");
        }

        public async Task<long> GetNumOutcomesAsyncCall(long augEvent)
        {
            var function = GetGetNumOutcomesFunction();
            return await function.CallAsync<long>(augEvent);
        }

        public async Task<string> GetNumOutcomesAsync(string addressFrom, long augEvent, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetNumOutcomesFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent);
        }

        public Function GetSetOutcomeFunction()
        {
            return contract.GetFunction("setOutcome");
        }

        public async Task<long> SetOutcomeAsyncCall(long ID, long outcome)
        {
            var function = GetSetOutcomeFunction();
            return await function.CallAsync<long>(ID, outcome);
        }

        public async Task<string> SetOutcomeAsync(string addressFrom, long ID, long outcome, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetSetOutcomeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID, outcome);
        }
    }
}