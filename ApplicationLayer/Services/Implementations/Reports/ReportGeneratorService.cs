using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.ApplicationLayer.Mapping;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Reports;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.Reports
{
    public class ReportGeneratorService : IReportGeneratorService
    {
        private readonly ITransactionsToReportMapper _transactionsToReportMapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IReportRepository _reportRepository;
        public ReportGeneratorService(
            ITransactionsToReportMapper transactionsToReportMapper,
            ITransactionRepository transactionRepository,
            IReportRepository reportRepository)
        {
            _transactionRepository = transactionRepository;
            _transactionsToReportMapper = transactionsToReportMapper;
            _reportRepository = reportRepository;
        }

        public async Task<GetReportDto> GenerateReport(ReportParamsDto reportParams, int userId)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserIdAsync(userId);
            transactions = transactions.Where(t => t.Date >= reportParams.StartDateTime && t.Date <= reportParams.EndDateTime).ToList();
            if (reportParams.CategoryId != null)
                transactions = transactions.Where(t => t.Categoryid == reportParams.CategoryId).ToList();
            if (reportParams.TransactionType != null)
                transactions = transactions.Where(t => t.Type == (char)reportParams.TransactionType).ToList();
            var report = await _transactionsToReportMapper.Map(transactions);

            await _reportRepository.AddReportAsync(report);

            var result = new GetReportDto
            {
                UserId = report.Userid,
                StartDateTime = report.Startdate,
                EndDateTime = report.Finishdate,
                TotalSum = report.Totalsum,
                ReportId = report.Reportid
            };
            return result;
        }
    }
}
