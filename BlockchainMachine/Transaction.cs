using System;

namespace BlockchainMachine
{
    public class Transaction
    {
        public string Sender { get; }
        public Guid Poll { get; }
        public int Option { get; }

        public Transaction(string sender, Guid poll, int option)
        {
            Sender = sender;
            Poll = poll;
            Option = option;
        }

        public override string ToString() =>
            $"Vote: from: {Sender} to: [{Poll} option: {Option}]";
    }
}