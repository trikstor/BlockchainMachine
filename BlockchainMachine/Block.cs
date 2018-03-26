using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockchainMachine
{
    public class Block
    {
        public int Index { get; }
        public DateTime Timestamp { get; }
        public List<Transaction> Transactions { get; }
        public string PreviousHash { get; }
        
        public Block(int index, List<Transaction> transactions, string previousHash)
        {
            Index = index;
            Timestamp = DateTime.UtcNow;
            Transactions = transactions;
            PreviousHash = previousHash;
        }

        public bool IsInBlock(Guid userToken) => Transactions.Any(transaction => transaction.Sender == userToken);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Block: {Index} generated at {Timestamp}\n");
            sb.Append("Transactions:\n");
            Transactions.ForEach(
                transaction => sb.Append($"\t{transaction.ToString()}\n"));
            sb.Append($"Hash of previous block: {PreviousHash}\n");

            return sb.ToString();
        }
    }
}