using System;

namespace L1Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.AccountNumber = 101;

            Console.WriteLine("Enter Deposit Amount:");
            double deposit = Convert.ToDouble(Console.ReadLine());
            account.Deposit(deposit);

            Console.WriteLine("Enter Withdraw Amount:");
            double withdraw = Convert.ToDouble(Console.ReadLine());
            account.Withdraw(withdraw);

            Console.WriteLine("Final Balance = " + account.Balance);
        }
    }
}