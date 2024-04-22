using System;
using System.Threading;

namespace a2_multithread
{
    internal class BankManager
    {
        private ListBox events;
        private ListBox output;

        private BankAccount bankAccount;
        private Security security;

        private List<Client> clients = new();

        private List<Thread> threads = new();

        private double totalAmountTransactioned;

        

        public BankManager(ListBox events, ListBox output)
        {
            this.events = events;
            this.output = output;

            bankAccount = new BankAccount(this);
            security = new Security();

            AddClients();
        }

        private void AddClients()
        {
            clients.Clear();

            for (int i = 0; i < 10; i++)
            {
                clients.Add(new Client(bankAccount, i, this));
            }
        }

        public void StartClients()
        {
            bool hasActiveThreads = threads.Any(thread => thread != null && thread.IsAlive);

            if (!hasActiveThreads)
            {
                AddClients();

                foreach (Client client in clients)
                {
                    Thread thread = new Thread(client.Run);
                    threads.Add(thread);
                    thread.Start(); // Start the thread
                }
            }

            foreach (Client client in clients)
            {
                client.Operating = true;
            }
        }

        public void StopClients()
        {
            try
            {
                foreach (Client client in clients)
                {
                    client.Operating = false;
                }

                foreach(Thread thread in threads)
                {
                    if (!thread.Join(TimeSpan.FromSeconds(5)))
                    {
                        Console.WriteLine("Thread join timed out. Aborting the thread.");
                        thread.Abort();
                    }
                }
                

                //WaitForThreads();
            }
            finally
            {
                
                threads.Clear();
                GatherResults();

            }
        }

        public void GatherResults()
        {
            foreach (Client client in clients)
            {
                totalAmountTransactioned += client.TotalAmountTransactioned;
            }

            string numberOfTransactions = $"Number of transactions: {bankAccount.NumberOfTransactions}";

            string numberOfErrors = $"Number of errors: {bankAccount.security.NumberOfErrors}";

            string transactionsSum = $"All transactions of clients sums into: {totalAmountTransactioned}, balance on account: {bankAccount.Balance}";

            string[] output = { numberOfTransactions, numberOfErrors, transactionsSum };

            UpdateOutput(output);

            
        }

        public void UpdateOutput(string[] _output)
        {
            if (output.InvokeRequired)
            {
                output.Invoke(new Action<string[]>(UpdateOutput), _output);
            }
            else
            {
                output.Items.Clear();
                output.Items.AddRange(_output);
            }
        }

        public void UpdateEventLogs(string eventMessage)
        {
            if (events.InvokeRequired)
            {
                events.Invoke(new Action<string>(UpdateEventLogs), eventMessage);
            }
            else
            {
                events.Items.Add(eventMessage);
            }
        }

    }
}
