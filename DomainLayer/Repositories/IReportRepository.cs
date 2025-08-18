using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface IReportRepository
    {
        Task AddReportAsync(Report report);
    }
}