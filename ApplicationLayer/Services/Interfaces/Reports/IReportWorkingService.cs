using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Reports
{
    public interface IReportWorkingService
    {
        Task<GetReportDto> GenerateReport(TransactionsFilterParams filterParams, int userId);
        Task DeleteReportByIdAsync(int reportId, int userId);
        Task<List<GetReportDto>> GetUsersReportsByUserIdAsync(int userId);
    }
}
