using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class BranchesService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""initDefaultBranch"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getBranches"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getMarketsInBranch"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32[]""}]},{""name"":""getPeriodLength"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getVotePeriod"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getNumMarketsBranch"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getMinTradingFee"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getNumBranches"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getBranch"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branchNumber"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""incrementPeriod"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""addMarket"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""augEvent"",""signature"":""i"",""type"":""int""},{""name"":""marketID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public BranchesService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetInitDefaultBranchFunction()
        {
            return contract.GetFunction("initDefaultBranch");
        }

        public async Task<long> InitDefaultBranchAsyncCall()
        {
            var function = GetInitDefaultBranchFunction();
            return await function.CallAsync<long>();
        }

        public async Task<string> InitDefaultBranchAsync(string addressFrom, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetInitDefaultBranchFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount);
        }

        public Function GetGetBranchesFunction()
        {
            return contract.GetFunction("getBranches");
        }

        public async Task<byte[][]> GetBranchesAsyncCall()
        {
            var function = GetGetBranchesFunction();
            return await function.CallAsync<byte[][]>();
        }

        public async Task<string> GetBranchesAsync(string addressFrom, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetBranchesFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount);
        }

        public Function GetGetMarketsInBranchFunction()
        {
            return contract.GetFunction("getMarketsInBranch");
        }

        public async Task<byte[][]> GetMarketsInBranchAsyncCall(long branch)
        {
            var function = GetGetMarketsInBranchFunction();
            return await function.CallAsync<byte[][]>(branch);
        }

        public async Task<string> GetMarketsInBranchAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMarketsInBranchFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetGetPeriodLengthFunction()
        {
            return contract.GetFunction("getPeriodLength");
        }

        public async Task<long> GetPeriodLengthAsyncCall(long branch)
        {
            var function = GetGetPeriodLengthFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> GetPeriodLengthAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetPeriodLengthFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetGetVotePeriodFunction()
        {
            return contract.GetFunction("getVotePeriod");
        }

        public async Task<long> GetVotePeriodAsyncCall(long branch)
        {
            var function = GetGetVotePeriodFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> GetVotePeriodAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetVotePeriodFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetGetNumMarketsBranchFunction()
        {
            return contract.GetFunction("getNumMarketsBranch");
        }

        public async Task<long> GetNumMarketsBranchAsyncCall(long branch)
        {
            var function = GetGetNumMarketsBranchFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> GetNumMarketsBranchAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetNumMarketsBranchFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetGetMinTradingFeeFunction()
        {
            return contract.GetFunction("getMinTradingFee");
        }

        public async Task<long> GetMinTradingFeeAsyncCall(long branch)
        {
            var function = GetGetMinTradingFeeFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> GetMinTradingFeeAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetMinTradingFeeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetGetNumBranchesFunction()
        {
            return contract.GetFunction("getNumBranches");
        }

        public async Task<long> GetNumBranchesAsyncCall()
        {
            var function = GetGetNumBranchesFunction();
            return await function.CallAsync<long>();
        }

        public async Task<string> GetNumBranchesAsync(string addressFrom, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetNumBranchesFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount);
        }

        public Function GetGetBranchFunction()
        {
            return contract.GetFunction("getBranch");
        }

        public async Task<byte[]> GetBranchAsyncCall(long branchNumber)
        {
            var function = GetGetBranchFunction();
            return await function.CallAsync<byte[]>(branchNumber);
        }

        public async Task<string> GetBranchAsync(string addressFrom, long branchNumber, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetBranchFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branchNumber);
        }

        public Function GetIncrementPeriodFunction()
        {
            return contract.GetFunction("incrementPeriod");
        }

        public async Task<long> IncrementPeriodAsyncCall(long branch)
        {
            var function = GetIncrementPeriodFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> IncrementPeriodAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetIncrementPeriodFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetAddMarketFunction()
        {
            return contract.GetFunction("addMarket");
        }

        public async Task<long> AddMarketAsyncCall(long augEvent, long marketID)
        {
            var function = GetAddMarketFunction();
            return await function.CallAsync<long>(augEvent, marketID);
        }

        public async Task<string> AddMarketAsync(string addressFrom, long augEvent, long marketID,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetAddMarketFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, augEvent, marketID);
        }
    }
}