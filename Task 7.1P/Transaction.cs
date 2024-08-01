using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    internal abstract class Transaction
    {
        protected decimal _amount;
        protected bool _success;
        protected bool _executed;
        protected bool _reversed;
        protected DateTime _dateStamp;

        public bool Success => _success;
        public bool Executed => _executed;
        public bool Reversed
        {
            get { return _reversed; }
            set { _reversed = value; }
        }
        public DateTime DateStamp => _dateStamp;

        // Constructor for the Transaction class
        public Transaction(decimal amount)
        {
            _amount = amount;
        }

        // Abstract method to execute the transaction (to be implemented by subclasses)
        public abstract void Execute();

        // Abstract method to rollback the transaction (to be implemented by subclasses)
        public abstract void Rollback();

        // Method to print transaction details
        public void Print()
        {
            Console.WriteLine($"Transaction Amount: {_amount:C}");
            Console.WriteLine($"Transaction Success: {_success}");
            Console.WriteLine($"Transaction Executed: {_executed}");
            Console.WriteLine($"Transaction Reversed: {_reversed}");
            Console.WriteLine($"Transaction DateStamp: {_dateStamp}");
        }
    }
}
