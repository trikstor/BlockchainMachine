using System;

namespace BlockchainMachine
{
    public class Node
    {
        public Guid UserToken { get; }

        public Node(Guid userToken)
        {
            UserToken = userToken;
        }
    }
}