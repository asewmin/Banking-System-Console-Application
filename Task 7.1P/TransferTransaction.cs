using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // TransferTransaction class to represent transfer transactions
    internal class TransferTransaction : Transaction
    {
        private Account _fromAccount;
        private Account _toAccount;

        // Constructor for TransferTransaction
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
        {
            // Ensure that 'fromAccount' and 'toAccount' parameters are not null and assign them to the private fields '_fromAccount' and '_toAccount'
            _fromAccount = fromAccount ?? throw new ArgumentNullException(nameof(fromAccount));
            _toAccount = toAccount ?? throw new ArgumentNullException(nameof(toAccount));
        }

        // Override the Execute method to perform the transfer transaction
        public override void Execute()
        {
            _executed = true; // Mark the transaction as executed
            _dateStamp = DateTime.Now; // Record the date and time of execution

            // Check if the 'fromAccount' has a sufficient balance for the transfer
            if (_fromAccount.Balance >= _amount)
            {
                _fromAccount.Balance -= _amount; // Deduct the transfer amount from 'fromAccount'
                _toAccount.Balance += _amount;   // Add the transfer amount to 'toAccount'
                _success = true;                // Mark the transaction as successful
            }
            else
            {
                _success = false; // Mark the transaction as unsuccessful (insufficient balance)
            }
        }

        // Override the Rollback method to reverse the transfer transaction
        public override void Rollback()
        {
            if (_executed && !_reversed)
            {
                _fromAccount.Balance += _amount; // Add back the transferred amount to 'fromAccount'
                _toAccount.Balance -= _amount;   // Deduct the transferred amount from 'toAccount'
                _success = false;               // Mark the transaction as unsuccessful (reversed)
                _reversed = true;               // Mark the transaction as reversed
                _dateStamp = DateTime.Now;      // Record the date and time of reversal
            }
        }
    }
}
