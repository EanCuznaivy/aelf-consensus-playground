using Acs4;
using AElf.Sdk.CSharp.State;
using AElf.Types;

namespace AElf.Contracts.Consensus.Naive
{
    public class NaiveConsensusContractState : ContractState
    {
        public MappedState<long, Address> Miners { get; set; }
    }
}