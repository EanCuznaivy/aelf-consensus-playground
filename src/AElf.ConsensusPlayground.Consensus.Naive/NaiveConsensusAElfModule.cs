using AElf.ConsensusPlayground.Consensus.Naive.Application;
using AElf.Kernel.SmartContract.Application;
using AElf.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AElf.ConsensusPlayground.Consensus.Naive
{
    public class NaiveConsensusAElfModule : AElfModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            services.AddTransient<IContractInitializationProvider, ConsensusContractInitializationProvider>();

        }
    }
}