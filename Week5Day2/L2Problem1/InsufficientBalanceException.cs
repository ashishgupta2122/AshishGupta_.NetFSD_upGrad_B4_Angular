using System;

namespace BankWithdrawalSystem
{
    // Custom Exception
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
}