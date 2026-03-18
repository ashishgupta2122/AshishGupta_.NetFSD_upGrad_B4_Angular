using System;

namespace BankWithdrawalSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Initial Balance: ");
                double balance = double.Parse(Console.ReadLine());

                BankAccount account = new BankAccount(balance);

                Console.Write("Enter Withdrawal Amount: ");
                double withdrawAmount = double.Parse(Console.ReadLine());

                account.Withdraw(withdrawAmount);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Transaction completed.");
            }

            Console.WriteLine("Program continues running...");
        }
    }
}