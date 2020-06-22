using System.Collections.Generic;
using AElf.Blockchains.BasicBaseChain;
using AElf.Database;
using AElf.Kernel.Blockchain.Application;
using AElf.Kernel.Consensus.AEDPoS;
using AElf.Kernel.Infrastructure;
using AElf.Kernel.SmartContract;
using AElf.Kernel.SmartContract.Application;
using AElf.Kernel.Txn.Application;
using AElf.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Modularity;

namespace AElf.ConsensusPlayground.MainChain
{
    [DependsOn(
        typeof(BasicBaseChainAElfModule)
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
            
            services.RemoveAll(s => s.ImplementationType == typeof(AEDPoSContractInitializationProvider));
            services.RemoveAll<IBlockValidationProvider>();
            services.RemoveAll<ITransactionValidationProvider>();
            
            services.AddTransient<IContractInitializationProvider, ConsensusContractInitializationProvider>();
            services.AddTransient<IContractDeploymentListProvider, MainChainContractDeploymentListProvider>();

            services.AddKeyValueDbContext<BlockchainKeyValueDbContext>(p => p.UseInMemoryDatabase());
            services.AddKeyValueDbContext<StateKeyValueDbContext>(p => p.UseInMemoryDatabase());
            
            Configure<ContractOptions>(o => o.ContractDeploymentAuthorityRequired = false);
        }
    }
}