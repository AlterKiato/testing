using System;
using System.Collections.Generic;

class ATM
{
    static double balance = 2000;
    static List<string> transactions = new List<string>(); 

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the ATM");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. View Transactions");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CheckBalance();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    Withdraw();
                    break;
                case "4":
                    ViewTransactions();
                    break;
                case "5":
                    Console.WriteLine("Thank you for using the ATM. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void CheckBalance()
    {
        Console.WriteLine($"Your current balance is: ${balance}");
    }

    static void Deposit()
    {
        Console.Write("Enter amount to deposit: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            balance += amount;
            transactions.Add($"Deposited: ${amount} | New Balance: ${balance}");
            Console.WriteLine($"Successfully deposited ${amount}. New balance: ${balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter amount to withdraw: ");
        if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
        {
            if (amount <= balance)
            {
                balance -= amount;
                transactions.Add($"Withdrew: ${amount} | Remaining Balance: ${balance}");
                Console.WriteLine($"Successfully withdrawn ${amount}. Remaining balance: ${balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    static void ViewTransactions()
    {
        Console.WriteLine("\nTransaction History:");
        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions yet.");
        }
        else
        {
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
