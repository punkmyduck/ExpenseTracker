using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public interface IReportToGetReportDtoMapper
    {
        Task<GetReportDto> Map(Report report);
        Task<List<GetReportDto>> Map(List<Report> reports);
    }
}
