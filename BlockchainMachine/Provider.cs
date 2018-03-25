using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockchainMachine
{
    public class Provider
    {
        private List<Transaction> transactions = new List<Transaction>();
        private List<Block> chain = new List<Block>();
        private List<Node> nodes = new List<Node>();
        private Block lastBlock => chain.Last();
        
        private bool IsInChain(Guid token) => chain.Any(block => block.IsInBlock(token));

        public bool TryCreateTransaction(Guid sender, Guid poll, int option)
        {
            if (IsInChain(sender))
                return false;
            transactions.Add(new Transaction(sender, poll, option));

            if (transactions.Count == 3)
            {
                chain.Add(CreateNewBlock(1));
                transactions.Clear();
            }
            
            return true;
        }
        
        private Block CreateNewBlock(int proof)
        {
            var preHash = chain.Count == 0 ? null : GetHash();

            return new Block(
                chain.Count, transactions, proof, preHash);
        }
    }
}