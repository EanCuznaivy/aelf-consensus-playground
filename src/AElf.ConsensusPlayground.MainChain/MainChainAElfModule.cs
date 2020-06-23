using AElf.ConsensusPlayground.Consensus.Naive;
using AElf.CrossChain;
using AElf.CrossChain.Grpc;
using AElf.CSharp.CodeOps;
using AElf.Database;
using AElf.EconomicSystem;
using AElf.GovernmentSystem;
using AElf.Kernel;
using AElf.Kernel.Infrastructure;
using AElf.Kernel.SmartContract;
using AElf.Kernel.SmartContract.Application;
using AElf.Kernel.SmartContract.Parallel;
using AElf.Kernel.Token;
using AElf.Modularity;
using AElf.OS;
using AElf.OS.Network.Grpc;
using AElf.Runtime.CSharp;
using AElf.RuntimeSetup;
using AElf.WebApp.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace AElf.ConsensusPlayground.MainChain
{
    [DependsOn(
        typeof(CrossChainAElfModule),
        typeof(KernelAElfModule),
        typeof(TokenKernelAElfModule),
        typeof(OSAElfModule),
        typeof(AbpAspNetCoreModule),
        typeof(CSharpRuntimeAElfModule),
        typeof(CSharpCodeOpsAElfModule),
        typeof(GrpcNetworkModule),
        typeof(RuntimeSetupAElfModule),
        typeof(GrpcCrossChainAElfModule),

        typeof(GovernmentSystemAElfModule),
        typeof(EconomicSystemAElfModule),

        //web api module
        typeof(WebWebAppAElfModule),
        typeof(ParallelExecutionModule),
        
        // new consensus module
        typeof(NaiveConsensusAElfModule)
    )]
    public class MainChainAElfModule : AElfModule
    {
        public ILogger<MainChainAElfModule> Logger { get; set; }

        public MainChainAElfModule()
        {
            Logger = NullLogger<MainChainAElfModule>.Instance;
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;
            
            services.AddTransient<IContractDeploymentListProvider, MainChainContractDeploymentListProvider>();

            services.AddKeyValueDbContext<BlockchainKeyValueDbContext>(p => p.UseInMemoryDatabase());
            services.AddKeyValueDbContext<StateKeyValueDbContext>(p => p.UseInMemoryDatabase());
            
            Configure<ContractOptions>(o => o.ContractDeploymentAuthorityRequired = false);
        }
    }
}