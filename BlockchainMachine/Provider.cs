using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainMachine
{
    public class Provider
    {
        private List<Transaction> transactions = new List<Transaction>();
        private List<Block> chain = new List<Block>();
        private List<Node> nodes = new List<Node>();
        private Node OperatorsNode { get; }

        public Provider(Node operatorsNode)
        {
            OperatorsNode = operatorsNode;
        }

        private bool IsInChain(Guid token) => chain.Any(block => block.IsInBlock(token));

        public bool TryCreateTransaction(Guid sender, Guid poll, int option)
        {
            if (IsInChain(sender))
                return false;
            transactions.Add(new Transaction(sender, poll, option));

            if (transactions.Count == 3)
            {
                chain.Add(CreateNewBlock());
                transactions.Clear();
            }

            return true;
        }

        private Block CreateNewBlock()
        {
            var preHash = chain.Count == 0 ? null : GetHash(chain.Last());

            return new Block(
                chain.Count, transactions, preHash);
        }

        private string GetHash(Block block) => GetSha256(block.ToString());

        private string GetSha256(string data)
        {
            var sha256 = new SHA256Managed();
            var hashBuilder = new StringBuilder();

            byte[] bytes = Encoding.Unicode.GetBytes(data);
            byte[] hash = sha256.ComputeHash(bytes);

            foreach (byte x in hash)
                hashBuilder.Append($"{x:x2}");

            return hashBuilder.ToString();
        }

        public string GetStringRepresentation()
        {
            return "";
        }
    }
}