using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class ExpiringEventsService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""getEventIndex"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""period"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getNumberEvents"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""},{""name"":""eventIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""getTotalRepReported"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getReportHash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""},{""name"":""reporter"",""signature"":""i"",""type"":""int""},{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""moveEventsToCurrentPeriod"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""currentVotePeriod"",""signature"":""i"",""type"":""int""},{""name"":""currentPeriod"",""signature"":""i"",""type"":""int""}],""outputs"":[]},{""name"":""addEvent"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""futurePeriod"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[]},{""name"":""setTotalRepReported"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""expDateIndex"",""signature"":""i"",""type"":""int""},{""name"":""repReported"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";

        private readonly Contract contract;

        public ExpiringEventsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetGetEventIndexFunction()
        {
            return contract.GetFunction("getEventIndex");
        }

        public async Task<long> GetEventIndexAsyncCall(long period, long eventID)
        {
            var function = GetGetEventIndexFunction();
            return await function.CallAsync<long>(period, eventID);
        }

        public async Task<string> GetEventIndexAsync(string addressFrom, long period, long eventID,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetEventIndexFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, period, eventID);
        }

        public Function GetGetEventsFunction()
        {
            return contract.GetFunction("getEvents");
        }

        public async Task<byte[][]> GetEventsAsyncCall(long branch, long expDateIndex)
        {
            var function = GetGetEventsFunction();
            return await function.CallAsync<byte[][]>(branch, expDateIndex);
        }

        public async Task<string> GetEventsAsync(string addressFrom, long branch, long expDateIndex,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetEventsFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, expDateIndex);
        }

        public Function GetGetNumberEventsFunction()
        {
            return contract.GetFunction("getNumberEvents");
        }

        public async Task<long> GetNumberEventsAsyncCall(long branch, long expDateIndex)
        {
            var function = GetGetNumberEventsFunction();
            return await function.CallAsync<long>(branch, expDateIndex);
        }

        public async Task<string> GetNumberEventsAsync(string addressFrom, long branch, long expDateIndex,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetNumberEventsFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, expDateIndex);
        }

        public Function GetGetEventFunction()
        {
            return contract.GetFunction("getEvent");
        }

        public async Task<byte[]> GetEventAsyncCall(long branch, long expDateIndex, long eventIndex)
        {
            var function = GetGetEventFunction();
            return await function.CallAsync<byte[]>(branch, expDateIndex, eventIndex);
        }

        public async Task<string> GetEventAsync(string addressFrom, long branch, long expDateIndex, long eventIndex,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetEventFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, expDateIndex, eventIndex);
        }

        public Function GetGetTotalRepReportedFunction()
        {
            return contract.GetFunction("getTotalRepReported");
        }

        public async Task<long> GetTotalRepReportedAsyncCall(long branch, long expDateIndex)
        {
            var function = GetGetTotalRepReportedFunction();
            return await function.CallAsync<long>(branch, expDateIndex);
        }

        public async Task<string> GetTotalRepReportedAsync(string addressFrom, long branch, long expDateIndex,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetTotalRepReportedFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, expDateIndex);
        }

        public Function GetGetReportHashFunction()
        {
            return contract.GetFunction("getReportHash");
        }

        public async Task<byte[]> GetReportHashAsyncCall(long branch, long expDateIndex, long reporter,
            long augEvent)
        {
            var function = GetGetReportHashFunction();
            return await function.CallAsync<byte[]>(branch, expDateIndex, reporter, augEvent);
        }

        public async Task<string> GetReportHashAsync(string addressFrom, long branch, long expDateIndex,
            long reporter, long augEvent, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetReportHashFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, expDateIndex, reporter,
                        augEvent);
        }

        public Function GetMoveEventsToCurrentPeriodFunction()
        {
            return contract.GetFunction("moveEventsToCurrentPeriod");
        }

        public async Task<long> MoveEventsToCurrentPeriodAsyncCall(long branch, long currentVotePeriod,
            long currentPeriod)
        {
            var function = GetMoveEventsToCurrentPeriodFunction();
            return await function.CallAsync<long>(branch, currentVotePeriod, currentPeriod);
        }

        public async Task<string> MoveEventsToCurrentPeriodAsync(string addressFrom, long branch,
            long currentVotePeriod, long currentPeriod, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetMoveEventsToCurrentPeriodFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, currentVotePeriod,
                        currentPeriod);
        }

        public Function GetAddEventFunction()
        {
            return contract.GetFunction("addEvent");
        }

        public async Task<long> AddEventAsyncCall(long branch, long futurePeriod, long eventID)
        {
            var function = GetAddEventFunction();
            return await function.CallAsync<long>(branch, futurePeriod, eventID);
        }

        public async Task<string> AddEventAsync(string addressFrom, long branch, long futurePeriod, long eventID,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetAddEventFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, futurePeriod, eventID);
        }

        public Function GetSetTotalRepReportedFunction()
        {
            return contract.GetFunction("setTotalRepReported");
        }

        public async Task<long> SetTotalRepReportedAsyncCall(long branch, long expDateIndex, long repReported)
        {
            var function = GetSetTotalRepReportedFunction();
            return await function.CallAsync<long>(branch, expDateIndex, repReported);
        }

        public async Task<string> SetTotalRepReportedAsync(string addressFrom, long branch, long expDateIndex,
            long repReported, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetSetTotalRepReportedFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, expDateIndex, repReported);
        }
    }
}