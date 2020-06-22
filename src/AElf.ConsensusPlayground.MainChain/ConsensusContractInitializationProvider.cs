using System.Collections.Generic;
using AElf.Kernel.Consensus;
using AElf.Kernel.SmartContract.Application;
using AElf.Types;

namespace AElf.ConsensusPlayground.MainChain
{
    public class ConsensusContractInitializationProvider : IContractInitializationProvider
    {
        public Hash SystemSmartContractName => ConsensusSmartContractAddressNameProvider.Name;
        public string ContractCodeName => "AElf.Contracts.Consensus.AEDPoS";

        public List<ContractInitializationMethodCall> GetInitializeMethodList(byte[] contractCode)
        {
            return new List<ContractInitializationMethodCall>();
        }
    }
}