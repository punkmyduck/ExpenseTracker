using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public class ReportToGetReportDtoMapper : IReportToGetReportDtoMapper
    {
        public Task<GetReportDto> Map(Report report)
        {
            var result = new GetReportDto
            {
                UserId = report.Userid,
                StartDateTime = report.Startdate,
                EndDateTime = report.Finishdate,
                TotalSum = report.Totalsum,
                ReportId = report.Reportid
            };
            return Task.FromResult(result);
        }

        public async Task<List<GetReportDto>> Map(List<Report> reports)
        {
            var result = new List<GetReportDto>();
            foreach (var r in reports)
            {
                result.Add(await Map(r));
            }
            return result;
        }
    }
}
