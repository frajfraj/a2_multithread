using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2_multithread
{
    internal class Stamp
    {
        private double balance;
        private int clientId;

        public double Balance { get { return balance; } set { balance = value; } }
        public int ClientId { get { return clientId; } set { clientId = value; } }

        public Stamp(double balance, int clientId)
        {
            Balance = balance;
            ClientId = clientId;
        }
    }
}
