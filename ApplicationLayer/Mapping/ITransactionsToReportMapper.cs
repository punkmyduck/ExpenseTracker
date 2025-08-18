using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public interface ITransactionsToReportMapper
    {
        Task<Report> Map(List<Transaction> transactions);
    }
}
