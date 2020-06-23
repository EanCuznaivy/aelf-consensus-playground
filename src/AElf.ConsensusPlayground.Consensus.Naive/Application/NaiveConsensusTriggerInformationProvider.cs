using AElf.Kernel.Account.Application;
using AElf.Kernel.Consensus.Application;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Volo.Abp.Threading;

namespace AElf.ConsensusPlayground.Consensus.Naive.Application
{
    public class NaiveConsensusTriggerInformationProvider : ITriggerInformationProvider
    {
        private readonly IAccountService _accountService;

        private ByteString Pubkey => ByteString.CopyFrom(AsyncHelper.RunSync(_accountService.GetPublicKeyAsync));

        public NaiveConsensusTriggerInformationProvider(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public BytesValue GetTriggerInformationForConsensusCommand(BytesValue consensusCommandBytes)
        {
            return new BytesValue {Value = Pubkey};
        }

        public BytesValue GetTriggerInformationForBlockHeaderExtraData(BytesValue consensusCommandBytes)
        {
            return new BytesValue {Value = Pubkey};
        }

        public BytesValue GetTriggerInformationForConsensusTransactions(BytesValue consensusCommandBytes)
        {
            return new BytesValue {Value = Pubkey};
        }
    }
}