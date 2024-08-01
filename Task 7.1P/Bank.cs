using Bank_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6._2P
{
    internal class Bank
    {
        private List<Account> _accounts;
        private List<Transaction> _transactions;

        public Bank()
        {
            _accounts = new List<Account>();
            _transactions = new List<Transaction>();
        }

        // Method to add an account to the bank
        public void AddAccount(Account account)
        {
            if (account != null)
            {
                _accounts.Add(account);
            }
        }

        // Method to get an account by name
        public Account? GetAccount(string name)
        {
            return _accounts.Find(account => account.Name == name);
        }

        // Method to execute a transaction and add it to the list of transactions
        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
        }

        // Method to rollback a transaction
        public void RollbackTransaction(Transaction transaction)
        {
            if (transaction.Executed && !transaction.Reversed)
            {
                transaction.Rollback();
                transaction.Reversed = true;
            }
            else
            {
                Console.WriteLine("Unable to rollback the transaction. Either it was not executed or it has already been reversed.");
            }
        }

        // Method to print all transactions
        public void PrintAllTransactions()
        {
            Console.WriteLine("List of Transactions:");
            foreach (Transaction transaction in _transactions)
            {
                transaction.Print();
            }
        }

        // Method to get the count of transactions
        public int GetTransactionsCount()
        {
            return _transactions.Count;
        }

        // Method to get a transaction by index
        public Transaction GetTransaction(int index)
        {
            if (index >= 0 && index < _transactions.Count)
            {
                return _transactions[index];
            }
            return null;
        }

        // Method to print the transaction history
        public void PrintTransactionHistory()
        {
            Console.WriteLine("Transaction History:");
            for (int i = 0; i < _transactions.Count; i++)
            {
                Transaction transaction = _transactions[i];
                Console.WriteLine($"Transaction {i}:");
                transaction.Print();
                Console.WriteLine();
            }
        }
    }
}
