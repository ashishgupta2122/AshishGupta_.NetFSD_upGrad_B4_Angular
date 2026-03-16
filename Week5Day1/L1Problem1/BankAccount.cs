using System;

namespace L1Problem1
{
    public class BankAccount
    {
        private int accountNumber;
        private double balance;

        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount");
                return;
            }

            balance += amount;
            Console.WriteLine("Current Balance = " + balance);
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }

            balance -= amount;
            Console.WriteLine("Current Balance = " + balance);
        }
    }
}