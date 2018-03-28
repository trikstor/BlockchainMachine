using System;

namespace BlockchainMachine
{
    public class Node
    {
        public string UserToken { get; }

        public Node(string userToken)
        {
            UserToken = userToken;
        }
    }
}