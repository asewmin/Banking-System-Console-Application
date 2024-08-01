using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // WithdrawTransaction class to represent withdrawal transactions
    internal class WithdrawTransaction : Transaction
    {
        private Account _account;

        // Constructor for WithdrawTransaction
        public WithdrawTransaction(Account account, decimal amount) : base(amount)
        {
            // Ensure that the 'account' parameter is not null, and assign it to the private field '_account'
            _account = account ?? throw new ArgumentNullException(nameof(account));
        }

        // Override the Execute method to perform the withdrawal transaction
        public override void Execute()
        {
            _executed = true; // Mark the transaction as executed
            _dateStamp = DateTime.Now; // Record the date and time of execution

            // Check if the account balance is sufficient for the withdrawal
            if (_account.Balance >= _amount)
            {
                _account.Balance -= _amount; // Subtract the withdrawal amount from the account balance
                _success = true; // Mark the transaction as successful
            }
            else
            {
                _success = false; // Mark the transaction as unsuccessful (insufficient balance)
            }
        }

        // Override the Rollback method to reverse the withdrawal transaction
        public override void Rollback()
        {
            if (_executed && !_reversed)
            {
                _account.Balance += _amount; // Add back the withdrawn amount to the account balance
                _success = false; // Mark the transaction as unsuccessful (reversed)
                _reversed = true; // Mark the transaction as reversed
                _dateStamp = DateTime.Now; // Record the date and time of reversal
            }
        }
    }
}
