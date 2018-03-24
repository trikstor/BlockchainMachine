using System;
using System.Collections.Generic;

namespace BlockchainMachine
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int Proof { get; set; }
        public string PreviousHash { get; set; }
    }
}