using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Reports
{
    public interface IReportGeneratorService
    {
        Task<GetReportDto> GenerateReport(ReportParamsDto reportParams, int userId);
    }
}
