using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // DepositTransaction class to represent deposit transactions
    internal class DepositTransaction : Transaction
    {
        private Account _account;

        // Constructor for DepositTransaction
        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            // Ensure that the 'account' parameter is not null, and assign it to the private field '_account'
            _account = account ?? throw new ArgumentNullException(nameof(account));
        }

        // Override the Execute method to perform the deposit transaction
        public override void Execute()
        {
            _executed = true; // Mark the transaction as executed
            _dateStamp = DateTime.Now; // Record the date and time of execution

            _account.Balance += _amount; // Add the deposit amount to the account balance
            _success = true; // Mark the transaction as successful
        }

        // Override the Rollback method to reverse the deposit transaction
        public override void Rollback()
        {
            if (_executed && !_reversed)
            {
                _account.Balance -= _amount; // Subtract the deposited amount from the account balance
                _success = false; // Mark the transaction as unsuccessful (reversed)
                _reversed = true; // Mark the transaction as reversed
                _dateStamp = DateTime.Now; // Record the date and time of reversal
            }
        }
    }
}
