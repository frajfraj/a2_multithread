using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2_multithread
{
    internal class BankAccount
    {
        private int numberOfTransactions;
        private double balance;
        public Security security;
        private BankManager bankManager; // Add reference to BankManager

        public double Balance { get { return balance; } set { balance = value; } }
        public int NumberOfTransactions { get { return numberOfTransactions; } set { numberOfTransactions = value; } }

        public BankAccount(BankManager manager)
        {
            balance = 0;
            numberOfTransactions = 0;
            security = new Security();
            bankManager = manager; // Assign the BankManager instance
        }

        public void Transaction(double amount, int clientId)
        {
            security.MakePreTransactionStamp(balance, clientId);
            balance = balance + amount;
            numberOfTransactions++;
            security.MakePostTransactionStamp(balance, clientId);
            security.VerifyLastTransaction(amount);

            if(amount > 0)
            {
                bankManager.UpdateEventLogs("Deposited: " + amount + "\n Balance: " + balance);
            }
            else
            {
                bankManager.UpdateEventLogs("Withdrawn: " + amount + "\n Balance: " + balance);
            }
            
        }
    }
}
