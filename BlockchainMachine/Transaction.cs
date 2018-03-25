using System;

namespace BlockchainMachine
{
    public class Transaction
    {
        public Guid Sender { get; }
        public Guid Poll { get; }
        public int Option { get; }

        public Transaction(Guid sender, Guid poll, int option)
        {
            Sender = sender;
            Poll = poll;
            Option = option;
        }
    }
}