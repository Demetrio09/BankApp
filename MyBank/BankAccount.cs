using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    public class BankAccount
    {

        public string Number { get; }

        public string Owner { get; set; }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }

        }

        private static int accountNumberSeed = 1234567890;

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now, $"Initial balance ${initialBalance}");
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive!");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must not be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds fot this transaction!");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        // Get account history
        public string GetAcccountHistory()
        {
            var report = new StringBuilder();

            decimal balance = 0;

            // HEADER
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                // ROWS
                report.AppendLine($"{item.Date.ToShortDateString()}\t${item.Amount}\t${balance}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
