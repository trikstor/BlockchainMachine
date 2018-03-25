using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockchainMachine
{
    public class Block
    {
        public int Index { get; }
        public DateTime Timestamp { get; }
        public List<Transaction> Transactions { get; }
        public int Proof { get; }
        public string PreviousHash { get; }
        
        public Block(int index, List<Transaction> transactions, int proof, string previousHash)
        {
            Index = index;
            Timestamp = DateTime.UtcNow;
            Transactions = transactions;
            Proof = proof;
            PreviousHash = previousHash;
        }

        public bool IsInBlock(Guid userToken) => Transactions.Any(transaction => transaction.Sender == userToken);
    }
}