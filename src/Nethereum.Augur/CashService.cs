using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class CashService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""addCash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""setCash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""address"",""signature"":""i"",""type"":""int""},{""name"":""balance"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initiateOwner"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""account"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""balance"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""send"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""recver"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""sendFrom"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""recver"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""},{""name"":""from"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""depositEther"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""withdrawEther"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""to"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public CashService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetAddCashFunction()
        {
            return contract.GetFunction("addCash");
        }

        public async Task<long> AddCashAsyncCall(long ID, long amount)
        {
            var function = GetAddCashFunction();
            return await function.CallAsync<long>(ID, amount);
        }

        public async Task<string> AddCashAsync(string addressFrom, long ID, long amount, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetAddCashFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID, amount);
        }

        public Function GetSetCashFunction()
        {
            return contract.GetFunction("setCash");
        }

        public async Task<long> SetCashAsyncCall(long address, long balance)
        {
            var function = GetSetCashFunction();
            return await function.CallAsync<long>(address, balance);
        }

        public async Task<string> SetCashAsync(string addressFrom, long address, long balance,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetSetCashFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, address, balance);
        }

        public Function GetInitiateOwnerFunction()
        {
            return contract.GetFunction("initiateOwner");
        }

        public async Task<long> InitiateOwnerAsyncCall(long account)
        {
            var function = GetInitiateOwnerFunction();
            return await function.CallAsync<long>(account);
        }

        public async Task<string> InitiateOwnerAsync(string addressFrom, long account, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetInitiateOwnerFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, account);
        }

        public Function GetBalanceFunction()
        {
            return contract.GetFunction("balance");
        }

        public async Task<long> BalanceAsyncCall(long address)
        {
            var function = GetBalanceFunction();
            return await function.CallAsync<long>(address);
        }

        public async Task<string> BalanceAsync(string addressFrom, long address, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetBalanceFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, address);
        }

        public Function GetSendFunction()
        {
            return contract.GetFunction("send");
        }

        public async Task<long> SendAsyncCall(long recver, long value)
        {
            var function = GetSendFunction();
            return await function.CallAsync<long>(recver, value);
        }

        public async Task<string> SendAsync(string addressFrom, long recver, long value, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetSendFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, recver, value);
        }

        public Function GetSendFromFunction()
        {
            return contract.GetFunction("sendFrom");
        }

        public async Task<long> SendFromAsyncCall(long recver, long value, long from)
        {
            var function = GetSendFromFunction();
            return await function.CallAsync<long>(recver, value, from);
        }

        public async Task<string> SendFromAsync(string addressFrom, long recver, long value, long from,
            HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetSendFromFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, recver, value, from);
        }

        public Function GetDepositEtherFunction()
        {
            return contract.GetFunction("depositEther");
        }

        public async Task<long> DepositEtherAsyncCall()
        {
            var function = GetDepositEtherFunction();
            return await function.CallAsync<long>();
        }

        public async Task<string> DepositEtherAsync(string addressFrom, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetDepositEtherFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount);
        }

        public Function GetWithdrawEtherFunction()
        {
            return contract.GetFunction("withdrawEther");
        }

        public async Task<long> WithdrawEtherAsyncCall(long to, long value)
        {
            var function = GetWithdrawEtherFunction();
            return await function.CallAsync<long>(to, value);
        }

        public async Task<string> WithdrawEtherAsync(string addressFrom, long to, long value, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetWithdrawEtherFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, to, value);
        }
    }
}