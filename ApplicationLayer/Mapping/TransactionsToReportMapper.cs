using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Enums;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public class TransactionsToReportMapper : ITransactionsToReportMapper
    {
        public Task<Report> Map(List<Transaction> transactions)
        {
            if (transactions == null || transactions.Count == 0)
                throw new ArgumentException("Transactions list cannot be empty", nameof(transactions));

            var first = transactions[0];
            var minDate = first.Date;
            var maxDate = first.Date;
            decimal totalSum = 0;

            foreach (var t in transactions)
            {
                if (t.Date < minDate) minDate = t.Date;
                if (t.Date > maxDate) maxDate = t.Date;
                totalSum = t.Type == (char)TransactionType.Expense ? totalSum - t.Amount : totalSum + t.Amount;
            }

            var report = new Report
            {
                Startdate = minDate,
                Finishdate = maxDate,
                Totalsum = totalSum,
                Userid = first.Userid
            };

            return Task.FromResult(report);
        }
    }
}
