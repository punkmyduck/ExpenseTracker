using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface IReportRepository
    {
        Task AddReportAsync(Report report);
        Task RemoveReportAsync(int reportId);
        Task<List<Report>> GetReportsByUserIdAsync(int userId);
        Task<bool> CheckReportsPermissionAsync(int reportId, int userId);
        Task<Report?> GetReportByIdAsync(int reportId);
    }
}