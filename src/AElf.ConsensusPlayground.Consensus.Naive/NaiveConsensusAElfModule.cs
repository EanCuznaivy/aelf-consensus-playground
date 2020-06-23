using AElf.ConsensusPlayground.Consensus.Naive.Application;
using AElf.Kernel.Consensus;
using AElf.Kernel.Consensus.Application;
using AElf.Kernel.Consensus.Scheduler.RxNet;
using AElf.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AElf.ConsensusPlayground.Consensus.Naive
{
    [DependsOn(
        typeof(RxNetSchedulerAElfModule),
        typeof(CoreConsensusAElfModule)
    )]
    public class NaiveConsensusAElfModule : AElfModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            // ITriggerInformationProvider is for generating some necessary information
            // to trigger consensus hints from consensus contract.
            services.AddSingleton<ITriggerInformationProvider, NaiveConsensusTriggerInformationProvider>();

            // IConsensusExtraDataExtractor is for extracting consensus data from extra data in Block Header.
            services.AddTransient<IConsensusExtraDataExtractor, NaiveConsensusExtraDataExtractor>();
            
            // IBroadcastPrivilegedPubkeyListProvider is just a helper for network module
            // to broadcast blocks to nodes of higher priority.
            services
                .AddSingleton<IBroadcastPrivilegedPubkeyListProvider, BroadcastPrivilegedPubkeyListProvider>();
        }
    }
}