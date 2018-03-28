using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BlockchainMachine.Tests
{
    [TestFixture]
    public class BlockShould
    {
        [Test]
        public void ReturnsStringRepresentationCorrectiy()
        {
            var block = new Block(3, new List<Transaction>
            {
                new Transaction("00000000-0000-0000-0000-000000000000", Guid.Empty, 1),
                new Transaction("00000000-0000-0000-0000-000000000000", Guid.Empty, 1),
                new Transaction("00000000-0000-0000-0000-000000000000", Guid.Empty, 1)
            }, "12345");

            var expectedResult = $"Block: 3 generated at {block.Timestamp}\n"+
                                 "Transactions:\n"+
                                 "\tVote: from: 00000000-0000-0000-0000-000000000000 to: [00000000-0000-0000-0000-000000000000 option: 1]\n"+
                                 "\tVote: from: 00000000-0000-0000-0000-000000000000 to: [00000000-0000-0000-0000-000000000000 option: 1]\n"+
                                 "\tVote: from: 00000000-0000-0000-0000-000000000000 to: [00000000-0000-0000-0000-000000000000 option: 1]\n"+
                                 "Hash of previous block: 12345\n";
            
            Assert.AreEqual(block.ToString(), expectedResult);
        }
    }
}