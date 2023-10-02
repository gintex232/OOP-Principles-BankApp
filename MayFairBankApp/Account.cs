using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayFairBankApp
{
    public class Account
    {
        public string AccountNumber { get; }
        public string AccountType { get; }
        public decimal Balance { get; private set; }
        public string OwnerName { get; }
        public string TransactionNote { get; }

        public Account(string accountNumber, string accountType, decimal initialbalance, string ownerName, string transactionNote)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            Balance = initialbalance;
            OwnerName = ownerName;
            TransactionNote = transactionNote;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;

        }
        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}
