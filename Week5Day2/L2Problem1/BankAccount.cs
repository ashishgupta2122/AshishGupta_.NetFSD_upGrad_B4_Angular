using System;

namespace BankWithdrawalSystem
{
    public class BankAccount
    {
        private double balance;

        public BankAccount(double initialBalance)
        {
            balance = initialBalance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {

                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            balance -= amount;
            Console.WriteLine($"Withdrawal successful! Remaining Balance: {balance}");
        }
    }
}