using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace a2_multithread
{
    internal class Client
    {
        private int id;
        private bool operating;
        private double totalAmountTransactioned;

        private BankAccount bankAccount;
        private BankManager bankManager;
        private Random random;

        public bool Operating { get { return operating; } set { operating = value; } }
        public double TotalAmountTransactioned { get { return totalAmountTransactioned; } set { totalAmountTransactioned = value; } }

        public Client(BankAccount bankAccount, int id, BankManager bankManager)
        {
            this.id = id;
            this.bankAccount = bankAccount;
            this.bankManager = bankManager;
            random = new Random();
        }

        public void Run()
        {
            operating = true; // Flag to control the loop
            while (operating)
            {
                // Randomly decide whether to deposit or withdraw
                bool deposit = random.Next(2) == 0; // 50% chance for deposit, 50% for withdraw

                // Generate a random amount for transaction
                double amount = random.NextDouble() * 1000; // Random amount up to 1000
                amount -= amount % 100;

                if (deposit)
                {
                    bankAccount.Transaction(amount, id); // Deposit the amount
                    totalAmountTransactioned += amount; // Update totalAmountTransactioned
                }
                else
                {
                    if(amount > bankAccount.Balance)
                    {
                        // Saves the world......
                    }
                    else 
                    {
                        bankAccount.Transaction(-amount, id); // Deposit the amount
                        totalAmountTransactioned -= amount; // Update totalAmountTransactioned
                    }
                }

                // Simulate some delay before next transaction
                Thread.Sleep(random.Next(100, 1000)); // Sleep for a random time between 100ms and 1000ms
            }
        }
    }
}
