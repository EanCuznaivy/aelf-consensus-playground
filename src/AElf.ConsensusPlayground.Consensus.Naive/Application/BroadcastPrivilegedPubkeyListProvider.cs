using System.Collections.Generic;
using System.Threading.Tasks;
using AElf.Kernel;
using AElf.Kernel.Consensus.Application;
using Volo.Abp.DependencyInjection;

namespace AElf.ConsensusPlayground.Consensus.Naive.Application
{
    // TODO: Make this as a default impl in AElf project.
    public class BroadcastPrivilegedPubkeyListProvider : IBroadcastPrivilegedPubkeyListProvider, ISingletonDependency
    {
        public Task<List<string>> GetPubkeyList(BlockHeader blockHeader)
        {
            return Task.FromResult(new List<string>());
        }
    }
}