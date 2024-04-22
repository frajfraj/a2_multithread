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

        private Object lockObject = new();

        public Object LockObject { get { return lockObject; } set { lockObject = value; } }

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
            //Unlock this lock for no errors

            //lock (lockObject)
            //{
                security.MakePreTransactionStamp(balance, clientId);
                balance = balance + amount;
                numberOfTransactions++;
                security.MakePostTransactionStamp(balance, clientId);
                security.VerifyLastTransaction(amount);

                if (amount > 0)
                {
                    bankManager.UpdateEventLogs("Deposited: " + amount + "\n Balance: " + balance);
                }
                else
                {
                    bankManager.UpdateEventLogs("Withdrawn: " + amount + "\n Balance: " + balance);
                }

                if (amount > balance)
                {
                    bankManager.UpdateEventLogs("Withdrawal denied, insufficient funds");
                    return;
                }
            //}
        }
    }
}
