using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // Account class to represent bank accounts
    internal class Account
    {
        public string Name { get; }    // Property to store the account holder's name
        public decimal Balance { get; set; }  // Property to store the account balance

        // Constructor for the Account class
        public Account(string name, decimal balance)
        {
            Name = name;          // Initialize the account name
            Balance = balance;    // Initialize the account balance
        }
    }
}
