using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;

namespace Nethereum.Augur
{
    public class InfoService
    {
        private readonly Web3.Web3 web3;

        private readonly string abi =
            @"[{""name"":""getCreator"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""address""}]},{""name"":""getCreationFee"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]},{""name"":""getDescription"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""bytes32""}]},{""name"":""setInfo"",""type"":""function"",""serpent"":true,""constant"":false,""inputs"":[{""name"":""ID"",""signature"":""i"",""type"":""int""},{""name"":""description"",""signature"":""s"",""type"":""string""},{""name"":""creator"",""signature"":""i"",""type"":""int""},{""name"":""fee"",""signature"":""i"",""type"":""int""}],""outputs"":[{""name"":"""",""type"":""int""}]}]";

        private readonly Contract contract;

        public InfoService(Web3.Web3 web3, string address)
        {
            this.web3 = web3;
            contract = web3.Eth.GetContract(abi, address);
        }

        public Function GetGetCreatorFunction()
        {
            return contract.GetFunction("getCreator");
        }

        public async Task<string> GetCreatorAsyncCall(long ID)
        {
            var function = GetGetCreatorFunction();
            return await function.CallAsync<string>(ID);
        }

        public async Task<string> GetCreatorAsync(string addressFrom, long ID, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetCreatorFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID);
        }

        public Function GetGetCreationFeeFunction()
        {
            return contract.GetFunction("getCreationFee");
        }

        public async Task<long> GetCreationFeeAsyncCall(long ID)
        {
            var function = GetGetCreationFeeFunction();
            return await function.CallAsync<long>(ID);
        }

        public async Task<string> GetCreationFeeAsync(string addressFrom, long ID, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetCreationFeeFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID);
        }

        public Function GetGetDescriptionFunction()
        {
            return contract.GetFunction("getDescription");
        }

        public async Task<byte[]> GetDescriptionAsyncCall(long ID)
        {
            var function = GetGetDescriptionFunction();
            return await function.CallAsync<byte[]>(ID);
        }

        public async Task<string> GetDescriptionAsync(string addressFrom, long ID, HexBigInteger gas = null,
            HexBigInteger valueAmount = null)
        {
            var function = GetGetDescriptionFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID);
        }

        public Function GetSetInfoFunction()
        {
            return contract.GetFunction("setInfo");
        }

        public async Task<long> SetInfoAsyncCall(long ID, string description, long creator, long fee)
        {
            var function = GetSetInfoFunction();
            return await function.CallAsync<long>(ID, description, creator, fee);
        }

        public async Task<string> SetInfoAsync(string addressFrom, long ID, string description, long creator,
            long fee, HexBigInteger gas = null, HexBigInteger valueAmount = null)
        {
            var function = GetSetInfoFunction();
            return await function.SendTransactionAsync(addressFrom, gas, valueAmount, ID, description, creator, fee);
        }
    }
}