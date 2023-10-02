using MayFairBankApp;

public class Program
{
    static void Main(string[] args)
    {
        //sets the title of the Console window
        Console.Title = "May Fair Bank App";
        //sets the foreground color to yello
        Console.ForegroundColor = ConsoleColor.Yellow;


        Bank bank = new Bank();
        //adding of accounts
        Account savingsAccount = new Account("234234234", "Savings", 10000.0m, "John Doe", "Gift");
        bank.AddAccount(savingsAccount);

        Account currentAccount = new Account("456456456", "Current", 10000.0m, "John Doe", "Food");
        bank.AddAccount(currentAccount);

        string accountNumber;
        bool isRunning = true;

        while (isRunning)
        {   //options for transaction purposes
            Console.WriteLine("\t\t\t====================== WELCOME TO MAY FAIR BANK ======================\n");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Transfer");
            Console.WriteLine("4. Print Account Details");
            Console.WriteLine("5. Transaction History");
            Console.WriteLine("6. Exit");
            Console.WriteLine("====================================");

            Console.WriteLine("Select Your Option: ");

            string input = Console.ReadLine();

            Console.Clear();//clears screen after each operation


            switch (input)
            {
                case "1"://For deposit operations
                    Console.Write("Enter account number: ");
                    accountNumber = Console.ReadLine();
                    Console.Write("Enter deposit Amount: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    bank.Deposit(accountNumber, depositAmount);
                    break;
                case "2"://for withdrawal operations
                    Console.Write("Enter account Number: ");
                    accountNumber = Console.ReadLine();
                    Console.Write("Enter Withdrawal Amount: ");
                    decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                    bank.Withdraw(accountNumber, withdrawalAmount);
                    break;
                case "3"://for transfer operations
                    Console.Write("Enter Source Account: ");
                    string sourceAccountNumber = Console.ReadLine();
                    Console.Write("Enter Beneficiary Account: ");
                    string destinationAccountNumber = Console.ReadLine();
                    Console.Write("Enter Transfer Amount: ");
                    decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
                    bank.Transfer(sourceAccountNumber, destinationAccountNumber, transferAmount);
                    break;
                case "4"://to preview details for each account
                    Console.Write("Enter account number: ");
                    accountNumber = Console.ReadLine();
                    bank.PrintAccountDetails(accountNumber);
                    break;
                case "5"://prints the statement of account for all accounts
                    bank.PrintAllAccounts();
                    break;
                case "6":
                    isRunning = false;
                    Console.WriteLine("THANKS FOR USING MAYFAIR BANK APP");
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please try again,");
                    break;
            }
            Console.WriteLine();
        }

    }
}