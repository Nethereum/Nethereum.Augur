using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class ConsensusService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""proportionCorrect"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""},{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""period"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""incrementPeriodAfterReporting"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""penalizeNotEnoughReports"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""collectFees"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""penalizeWrong"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""augEvent"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""penalizationCatchup"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""slashRep"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""salt"",""signature"":""i"",""type"":""int""},{""name"":""report"",""signature"":""i"",""type"":""int""},{""name"":""reporter"",""signature"":""i"",""type"":""int""},{""name"":""eventID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public ConsensusService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetProportionCorrectFunction()
        {
            return contract.GetFunction("proportionCorrect");
        }

        public async Task<long> ProportionCorrectAsyncCall(long augEvent, long branch, long period)
        {
            var function = GetProportionCorrectFunction();
            return await function.CallAsync<long>(augEvent, branch, period);
        }

        public async Task<string> ProportionCorrectAsync(string addressFrom, long augEvent, long branch, long period,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetProportionCorrectFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent, branch, period);
        }

        public Function GetIncrementPeriodAfterReportingFunction()
        {
            return contract.GetFunction("incrementPeriodAfterReporting");
        }

        public async Task<long> IncrementPeriodAfterReportingAsyncCall(long branch)
        {
            var function = GetIncrementPeriodAfterReportingFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> IncrementPeriodAfterReportingAsync(string addressFrom, long branch,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetIncrementPeriodAfterReportingFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetPenalizeNotEnoughReportsFunction()
        {
            return contract.GetFunction("penalizeNotEnoughReports");
        }

        public async Task<long> PenalizeNotEnoughReportsAsyncCall(long branch)
        {
            var function = GetPenalizeNotEnoughReportsFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> PenalizeNotEnoughReportsAsync(string addressFrom, long branch,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetPenalizeNotEnoughReportsFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetCollectFeesFunction()
        {
            return contract.GetFunction("collectFees");
        }

        public async Task<long> CollectFeesAsyncCall(long branch)
        {
            var function = GetCollectFeesFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> CollectFeesAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetCollectFeesFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetPenalizeWrongFunction()
        {
            return contract.GetFunction("penalizeWrong");
        }

        public async Task<long> PenalizeWrongAsyncCall(long branch, long augEvent)
        {
            var function = GetPenalizeWrongFunction();
            return await function.CallAsync<long>(branch, augEvent);
        }

        public async Task<string> PenalizeWrongAsync(string addressFrom, long branch, long augEvent,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetPenalizeWrongFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, augEvent);
        }

        public Function GetPenalizationCatchupFunction()
        {
            return contract.GetFunction("penalizationCatchup");
        }

        public async Task<long> PenalizationCatchupAsyncCall(long branch)
        {
            var function = GetPenalizationCatchupFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> PenalizationCatchupAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetPenalizationCatchupFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetSlashRepFunction()
        {
            return contract.GetFunction("slashRep");
        }

        public async Task<long> SlashRepAsyncCall(long branch, long salt, long report, long reporter, long eventID)
        {
            var function = GetSlashRepFunction();
            return await function.CallAsync<long>(branch, salt, report, reporter, eventID);
        }

        public async Task<string> SlashRepAsync(string addressFrom, long branch, long salt, long report,
            long reporter, long eventID, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetSlashRepFunction();
            return
                await
                    function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, salt, report, reporter, eventID);
        }
    }
}