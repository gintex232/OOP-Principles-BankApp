using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayFairBankApp
{
    public class Bank//Bank class
    {
        private List<Account> accounts;

        public Bank()
        {
            accounts = new List<Account>();
        }
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
        public Account GetAccount(string accountNumber)
        {
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
        public void RemoveAccount(string accountNumber)
        {
            Account account = GetAccount(accountNumber);
            if (account != null)
            {
                accounts.Remove(account);
                Console.WriteLine("Account removed successfully.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
        public void Deposit(string accountNumber, decimal amount)
        {
            Account account = GetAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
                Console.WriteLine($"Deposit Successful. New Balance: {account.Balance:C}");
            }
            else
            {
                Console.WriteLine("Account not Found");
            }
        }
        public void Withdraw(string accountNumber, decimal amount)
        {
            Account account = GetAccount(accountNumber);
            if (account != null)
            {
                if (account.Withdraw(amount))
                {
                    Console.WriteLine($"Withdrawal Sucessful. Balance: {account.Balance:C}");
                }
                else
                {
                    Console.WriteLine("Insufficient Funds.");
                }

            }
            else
            {
                Console.WriteLine("Account Not Found.");
            }

        }
        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            Account fromAccount = GetAccount(fromAccountNumber);
            Account toAccount = GetAccount(toAccountNumber);
            if (fromAccount != null && toAccount != null)
            {
                if (fromAccount.Withdraw(amount))
                {
                    toAccount.Deposit(amount);
                    Console.WriteLine("Transfer Successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient Funds.");
                }
            }
            else
            {
                Console.WriteLine("One or both accounts not found.");
            }
        }
        public void PrintAccountDetails(string accountNumber)
        {
            Account account = GetAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine("Account Details: ");
                Console.WriteLine($"Account Number: {account.AccountNumber}");
                Console.WriteLine($"Account Type: {account.AccountType}");
                Console.WriteLine($"Balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account Not Found.");
            }
        }
        public void PrintAllAccounts()
        {

            Console.WriteLine("\t\t\t\tSTATEMENT OF ACCOUNTS \n");
            Console.WriteLine("|----------------|---------------|---------------|----------------|---------------|");
            Console.WriteLine("|ACCOUNT NAME    | ACCOUNT NUMBER| ACCOUNT TYPE  | BALANCE        | NOTE          |");
            Console.WriteLine("|--------------- |---------------|---------------|----------------|---------------|");
            foreach (Account account in accounts)
            {
                Console.WriteLine($"| {account.OwnerName}       | {account.AccountNumber,-14}| {account.AccountType,-12}  | {account.Balance,-13:C}  | {account.TransactionNote}          |");
            }
            Console.WriteLine("|----------------|---------------|---------------|----------------|---------------|\n");
        }
    }
}
