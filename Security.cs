using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2_multithread
{
    internal class Security
    {
        private int numberOfErrors;

        public int NumberOfErrors { get { return numberOfErrors; } set { numberOfErrors = value; } }

        private List<Stamp> transactionHistory = new List<Stamp>();

        public List<Stamp> TransactionHistory { get { return transactionHistory; } set { transactionHistory = value; } }

        public void MakePreTransactionStamp(double balance, int clientId)
        {
            // Create a new stamp representing the pre-transaction state
            Stamp preTransactionStamp = new Stamp(balance, clientId);
            transactionHistory.Add(preTransactionStamp);
        }

        public void MakePostTransactionStamp(double balance, int clientId)
        {
            // Create a new stamp representing the post-transaction state
            Stamp postTransactionStamp = new Stamp(balance, clientId);
            transactionHistory.Add(postTransactionStamp);
        }

        public void VerifyLastTransaction(double amount)
        {
            // Verify the last transaction (if necessary)
            if (transactionHistory.Count >= 2)
            {
                Stamp preTransaction = transactionHistory[transactionHistory.Count - 2];
                Stamp postTransaction = transactionHistory[transactionHistory.Count - 1];

                // Example verification logic: Check if balance increased after transaction
                if (postTransaction.Balance != preTransaction.Balance + amount)
                {
                    numberOfErrors++; // Increment error count
                }
            }
        }
    }
}
