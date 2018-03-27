using System;
using System.Linq;
using NUnit.Framework;

namespace BlockchainMachine.Tests
{
    [TestFixture]
    public class BlockChainShould
    {        
        [Test]
        public void CreateTransactionCorrectly()
        {
            var blockChain = new BlockChain(new Node(Guid.Empty), 3);
            var polls = new[] {Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()};
            
            for (var i = 0; i < 3; i++)
            {
                blockChain.TryCreateTransaction(polls[i], i);
            }
            
            var expectedResult = "BlockChain:\n"+
            $"Block: 0 generated at {Chain.chain.First().Timestamp}\n"+
            "Transactions:\n"+
            $"\tVote: from: 00000000-0000-0000-0000-000000000000 to: [{Chain.chain.First().Transactions[0].Poll} option: 0]\n"+
            $"\tVote: from: 00000000-0000-0000-0000-000000000000 to: [{Chain.chain.First().Transactions[1].Poll} option: 1]\n"+
            $"\tVote: from: 00000000-0000-0000-0000-000000000000 to: [{Chain.chain.First().Transactions[2].Poll} option: 2]\n"+
            "Hash of previous block: \n";
            
            Assert.AreEqual(blockChain.ToString(), expectedResult);
        }
    }
}