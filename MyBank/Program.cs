using System;

namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Demetrio", 500);

            Console.WriteLine($"Account number: {account.Number} open by {account.Owner} has initial balance of ${account.Balance}");

            account.MakeWithdrawal(100, DateTime.Now, "dinner");
            Console.WriteLine($"Withdrawal done! Your new balance is ${account.Balance}!");
            account.MakeDeposit(200, DateTime.Now, "pay day");
            Console.WriteLine($"Deposit done! My new balance is ${account.Balance}!");

            // Geeting the account history.
            Console.WriteLine(account.GetAcccountHistory());

            // Test that the initial balance must be posite
            try
            {
                var invalidAccount = new BankAccount("second account", 55);
                Console.WriteLine($"New account number {invalidAccount.Number} initial balance {invalidAccount.Balance}");
                Console.WriteLine(invalidAccount.GetAcccountHistory());
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("exeption caught creating an invalid account");
                Console.WriteLine(e.ToString());
            }

        }
    }
}
