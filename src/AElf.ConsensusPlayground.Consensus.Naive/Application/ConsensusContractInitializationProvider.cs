using System.Collections.Generic;
using AElf.Kernel.Consensus;
using AElf.Kernel.SmartContract.Application;
using AElf.Types;
using Volo.Abp.DependencyInjection;

namespace AElf.ConsensusPlayground.Consensus.Naive.Application
{
    public class ConsensusContractInitializationProvider : IContractInitializationProvider, ITransientDependency
    {
        public Hash SystemSmartContractName => ConsensusSmartContractAddressNameProvider.Name;
        public string ContractCodeName => "AElf.Contracts.Consensus.Naive";

        public List<ContractInitializationMethodCall> GetInitializeMethodList(byte[] contractCode)
        {
            return new List<ContractInitializationMethodCall>();
        }
    }
}