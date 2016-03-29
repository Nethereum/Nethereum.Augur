using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class ReportingWhitelistService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""getRepBalance"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getRepByIndex"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""repIndex"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getReporterID"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""index"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""address""}]},{""name"":""getReputation"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int[]""}]},{""name"":""getNumberReporters"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""repIDToIndex"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""},{""name"":""repID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getTotalRep"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""hashReport"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""report"",""signature"":""a"",""type"":""bytes32[]""},{""name"":""salt"",""signature"":""i"",""type"":""int""}],""outputs"":[]}]";

        private readonly Contract contract;

        public ReportingWhitelistService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetGetRepBalanceFunction()
        {
            return contract.GetFunction("getRepBalance");
        }

        public async Task<long> GetRepBalanceAsyncCall(long branch, long address)
        {
            var function = GetGetRepBalanceFunction();
            return await function.CallAsync<long>(branch, address);
        }

        public async Task<string> GetRepBalanceAsync(string addressFrom, long branch, long address,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetRepBalanceFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, address);
        }

        public Function GetGetRepByIndexFunction()
        {
            return contract.GetFunction("getRepByIndex");
        }

        public async Task<long> GetRepByIndexAsyncCall(long branch, long repIndex)
        {
            var function = GetGetRepByIndexFunction();
            return await function.CallAsync<long>(branch, repIndex);
        }

        public async Task<string> GetRepByIndexAsync(string addressFrom, long branch, long repIndex,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetRepByIndexFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, repIndex);
        }

        public Function GetGetReporterIDFunction()
        {
            return contract.GetFunction("getReporterID");
        }

        public async Task<string> GetReporterIDAsyncCall(long branch, long index)
        {
            var function = GetGetReporterIDFunction();
            return await function.CallAsync<string>(branch, index);
        }

        public async Task<string> GetReporterIDAsync(string addressFrom, long branch, long index,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetGetReporterIDFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, index);
        }

        public Function GetGetReputationFunction()
        {
            return contract.GetFunction("getReputation");
        }

        public async Task<long[]> GetReputationAsyncCall(long address)
        {
            var function = GetGetReputationFunction();
            return await function.CallAsync<long[]>(address);
        }

        public async Task<string> GetReputationAsync(string addressFrom, long address, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetReputationFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, address);
        }

        public Function GetGetNumberReportersFunction()
        {
            return contract.GetFunction("getNumberReporters");
        }

        public async Task<long> GetNumberReportersAsyncCall(long branch)
        {
            var function = GetGetNumberReportersFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> GetNumberReportersAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetNumberReportersFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetRepIDToIndexFunction()
        {
            return contract.GetFunction("repIDToIndex");
        }

        public async Task<long> RepIDToIndexAsyncCall(long branch, long repID)
        {
            var function = GetRepIDToIndexFunction();
            return await function.CallAsync<long>(branch, repID);
        }

        public async Task<string> RepIDToIndexAsync(string addressFrom, long branch, long repID,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetRepIDToIndexFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch, repID);
        }

        public Function GetGetTotalRepFunction()
        {
            return contract.GetFunction("getTotalRep");
        }

        public async Task<long> GetTotalRepAsyncCall(long branch)
        {
            var function = GetGetTotalRepFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> GetTotalRepAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetTotalRepFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetHashReportFunction()
        {
            return contract.GetFunction("hashReport");
        }

        public async Task<byte[][]> HashReportAsyncCall(byte[][] report, long salt)
        {
            var function = GetHashReportFunction();
            return await function.CallAsync<byte[][]>(report, salt);
        }

        public async Task<string> HashReportAsync(string addressFrom, byte[][] report, long salt,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetHashReportFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, report, salt);
        }
    }
}