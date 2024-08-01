using Bank_System;
using Task_6._2P;

// BankSystem class to manage bank operations
internal class BankSystem
{
    private static Account FindAccount(Bank bank)
    {
        Console.Write("Enter account name: ");
        string accountName = Console.ReadLine();

        Account foundAccount = bank.GetAccount(accountName);

        if (foundAccount == null)
        {
            Console.WriteLine("Account not found.");
        }

        return foundAccount;
    }

    // Method to perform a deposit transaction
    private static void DoDeposit(Bank bank)
    {
        Account account = FindAccount(bank);

        if (account != null)
        {
            Console.Write("Enter the deposit amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            DepositTransaction depositTransaction = new DepositTransaction(account, amount);
            bank.ExecuteTransaction(depositTransaction);
            Console.WriteLine("Deposit successful.");
        }
    }

    // Method to perform a withdrawal transaction
    private static void DoWithdraw(Bank bank)
    {
        Account account = FindAccount(bank);

        if (account != null)
        {
            Console.Write("Enter the withdrawal amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            WithdrawTransaction withdrawTransaction = new WithdrawTransaction(account, amount);
            bank.ExecuteTransaction(withdrawTransaction);
            Console.WriteLine("Withdrawal successful.");
        }
    }

    // Method to perform a transfer transaction
    private static void DoTransfer(Bank bank)
    {
        Account fromAccount = FindAccount(bank);

        if (fromAccount != null)
        {
            Account toAccount = FindAccount(bank);

            if (toAccount != null)
            {
                Console.Write("Enter the transfer amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                TransferTransaction transferTransaction = new TransferTransaction(fromAccount, toAccount, amount);
                bank.ExecuteTransaction(transferTransaction);
                Console.WriteLine("Transfer successful.");
            }
        }
    }

    // Method to print the details of an account
    private static void DoPrint(Bank bank)
    {
        Account account = FindAccount(bank);

        if (account != null)
        {
            Console.WriteLine($"Account Name: {account.Name}");
            Console.WriteLine($"Balance: {account.Balance:C}");
        }
    }

    // Method to perform a rollback of a transaction
    private static void DoRollback(Bank bank)
    {
        bank.PrintAllTransactions();
        Console.Write("Enter the index of the transaction to rollback: ");
        int transactionIndex = Convert.ToInt32(Console.ReadLine());

        if (transactionIndex >= 0 && transactionIndex < bank.GetTransactionsCount())
        {
            Transaction transaction = bank.GetTransaction(transactionIndex);
            bank.RollbackTransaction(transaction);
            Console.WriteLine("Transaction rolled back successfully.");
        }
        else
        {
            Console.WriteLine("Invalid transaction index. Please try again.");
        }
    }

    static void Main(string[] args)
    {
        Bank bank = new Bank();
        int choice;

        do
        {
            Console.WriteLine("1. Add new account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("5. Print account details");
            Console.WriteLine("6. Print transaction history");
            Console.WriteLine("7. Rollback transaction");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter account name: ");
                    string accountName = Console.ReadLine();
                    Console.Write("Enter starting balance: ");
                    decimal startingBalance = Convert.ToDecimal(Console.ReadLine());

                    Account newAccount = new Account(accountName, startingBalance);
                    bank.AddAccount(newAccount);
                    Console.WriteLine("Account added successfully.");
                    break;

                case 2:
                    DoDeposit(bank);
                    break;

                case 3:
                    DoWithdraw(bank);
                    break;

                case 4:
                    DoTransfer(bank);
                    break;

                case 5:
                    DoPrint(bank);
                    break;

                case 6:
                    bank.PrintTransactionHistory(); // Print transaction history
                    break;

                case 7:
                    DoRollback(bank); // Rollback a transaction
                    break;

                case 0:
                    Console.WriteLine("Exiting the program.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        } while (choice != 0);
    }
}
