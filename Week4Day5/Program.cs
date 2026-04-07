using System;


class BankAccount
{
    private double balance;

    public void Deposit(double amount)
    {
        balance = balance + amount;
    }

    public void withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance = balance - amount;
        }
        else
        {
            Console.WriteLine("Insufficient Balance");
        }
    }

    public double GetBalance()
    {
        return balance;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        BankAccount account = new BankAccount();

        Console.Write("Enter Deposit Amount: ");
        double depositAmount = Convert.ToDouble(Console.ReadLine());

        account.Deposit(depositAmount);

        Console.Write("Enter Withdraw Amount: ");
        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
        account.withdraw(withdrawAmount);

        Console.WriteLine("Current Balance = " + account.GetBalance());
    }
}