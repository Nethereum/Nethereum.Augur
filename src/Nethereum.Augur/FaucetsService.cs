using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class FaucetsService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""reputationFaucet"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""cashFaucet"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""fundNewAccount"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""branch"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public FaucetsService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetReputationFaucetFunction()
        {
            return contract.GetFunction("reputationFaucet");
        }

        public async Task<long> ReputationFaucetAsyncCall(long branch)
        {
            var function = GetReputationFaucetFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> ReputationFaucetAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetReputationFaucetFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }

        public Function GetCashFaucetFunction()
        {
            return contract.GetFunction("cashFaucet");
        }

        public async Task<long> CashFaucetAsyncCall()
        {
            var function = GetCashFaucetFunction();
            return await function.CallAsync<long>();
        }

        public async Task<string> CashFaucetAsync(string addressFrom, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetCashFaucetFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount);
        }

        public Function GetFundNewAccountFunction()
        {
            return contract.GetFunction("fundNewAccount");
        }

        public async Task<long> FundNewAccountAsyncCall(long branch)
        {
            var function = GetFundNewAccountFunction();
            return await function.CallAsync<long>(branch);
        }

        public async Task<string> FundNewAccountAsync(string addressFrom, long branch, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetFundNewAccountFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, branch);
        }
    }
}