public class CashService
{
        private readonly Web3.Web3 web3;
        private string abi = @"[{""name"":""addCash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""},{""name"":""amount"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""setCash"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""address"",""signature"":""i"",""type"":""int""},{""name"":""balance"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""initiateOwner"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""account"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""balance"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""address"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""send"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""recver"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""sendFrom"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""recver"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""},{""name"":""from"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""depositEther"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""withdrawEther"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""to"",""signature"":""i"",""type"":""int""},{""name"":""value"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";
        private Contract contract;
        public CashService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }
        
        public Function GetAddCashFunction()
{
   return contract.GetFunction("addCash");
}
public async Task<Int64> AddCashAsyncCall(Int64  ID,Int64  amount)
{
   var function = GetAddCashFunction();
   return await function.CallAsync<Int64>(ID,amount);
}
public async Task<string> AddCashAsync(string addressFrom, Int64  ID,Int64  amount, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetAddCashFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID,amount);
}

public Function GetSetCashFunction()
{
   return contract.GetFunction("setCash");
}
public async Task<Int64> SetCashAsyncCall(Int64  address,Int64  balance)
{
   var function = GetSetCashFunction();
   return await function.CallAsync<Int64>(address,balance);
}
public async Task<string> SetCashAsync(string addressFrom, Int64  address,Int64  balance, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSetCashFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, address,balance);
}

public Function GetInitiateOwnerFunction()
{
   return contract.GetFunction("initiateOwner");
}
public async Task<Int64> InitiateOwnerAsyncCall(Int64  account)
{
   var function = GetInitiateOwnerFunction();
   return await function.CallAsync<Int64>(account);
}
public async Task<string> InitiateOwnerAsync(string addressFrom, Int64  account, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetInitiateOwnerFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, account);
}

public Function GetBalanceFunction()
{
   return contract.GetFunction("balance");
}
public async Task<Int64> BalanceAsyncCall(Int64  address)
{
   var function = GetBalanceFunction();
   return await function.CallAsync<Int64>(address);
}
public async Task<string> BalanceAsync(string addressFrom, Int64  address, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetBalanceFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, address);
}

public Function GetSendFunction()
{
   return contract.GetFunction("send");
}
public async Task<Int64> SendAsyncCall(Int64  recver,Int64  value)
{
   var function = GetSendFunction();
   return await function.CallAsync<Int64>(recver,value);
}
public async Task<string> SendAsync(string addressFrom, Int64  recver,Int64  value, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSendFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, recver,value);
}

public Function GetSendFromFunction()
{
   return contract.GetFunction("sendFrom");
}
public async Task<Int64> SendFromAsyncCall(Int64  recver,Int64  value,Int64  from)
{
   var function = GetSendFromFunction();
   return await function.CallAsync<Int64>(recver,value,from);
}
public async Task<string> SendFromAsync(string addressFrom, Int64  recver,Int64  value,Int64  from, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetSendFromFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, recver,value,from);
}

public Function GetDepositEtherFunction()
{
   return contract.GetFunction("depositEther");
}
public async Task<Int64> DepositEtherAsyncCall()
{
   var function = GetDepositEtherFunction();
   return await function.CallAsync<Int64>();
}
public async Task<string> DepositEtherAsync(string addressFrom,  HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetDepositEtherFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, );
}

public Function GetWithdrawEtherFunction()
{
   return contract.GetFunction("withdrawEther");
}
public async Task<Int64> WithdrawEtherAsyncCall(Int64  to,Int64  value)
{
   var function = GetWithdrawEtherFunction();
   return await function.CallAsync<Int64>(to,value);
}
public async Task<string> WithdrawEtherAsync(string addressFrom, Int64  to,Int64  value, HexBigInteger gas = null, HexBigInteger valueAmount = null)
{
    var function = GetWithdrawEtherFunction();
    return await function.SendTransactionAsync(addressFrom, gas, valueAmount, to,value);
}


}
