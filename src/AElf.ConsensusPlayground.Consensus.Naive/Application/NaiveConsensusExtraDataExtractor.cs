using System.Text;
using AElf.Kernel;
using AElf.Kernel.Consensus.Application;
using Google.Protobuf;

namespace AElf.ConsensusPlayground.Consensus.Naive.Application
{
    public class NaiveConsensusExtraDataExtractor : IConsensusExtraDataExtractor
    {
        public ByteString ExtractConsensusExtraData(BlockHeader header)
        {
            return ByteString.CopyFrom("AElf.ConsensusPlayground.Consensus.Naive", Encoding.UTF8);
        }
    }
}