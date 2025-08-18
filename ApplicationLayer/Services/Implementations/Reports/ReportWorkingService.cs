using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.ApplicationLayer.Mapping;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Reports;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.Reports
{
    public class ReportWorkingService : IReportWorkingService
    {
        private readonly ITransactionsToReportMapper _transactionsToReportMapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IReportToGetReportDtoMapper _reportToGetReportDtoMapper;
        public ReportWorkingService(
            ITransactionsToReportMapper transactionsToReportMapper,
            ITransactionRepository transactionRepository,
            IReportRepository reportRepository,
            IReportToGetReportDtoMapper reportToGetReportDtoMapper)
        {
            _transactionRepository = transactionRepository;
            _transactionsToReportMapper = transactionsToReportMapper;
            _reportRepository = reportRepository;
            _reportToGetReportDtoMapper = reportToGetReportDtoMapper;
        }

        public async Task<GetReportDto> GenerateReport(TransactionsFilterParams filterParams, int userId)
        {
            var transactions = await _transactionRepository.GetTransactionsByFilterAsync(filterParams, userId);
            var report = await _transactionsToReportMapper.Map(transactions);

            await _reportRepository.AddReportAsync(report);

            var result = await _reportToGetReportDtoMapper.Map(report);
            return result;
        }

        public async Task<List<GetReportDto>> GetUsersReportsByUserIdAsync(int userId)
        {
            var reports = await _reportRepository.GetReportsByUserIdAsync(userId);
            var result = await _reportToGetReportDtoMapper.Map(reports);
            return result;
        }

        public async Task DeleteReportByIdAsync(int reportId, int userId)
        {
            if (!await _reportRepository.CheckReportsPermissionAsync(reportId, userId))
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this report.");
            }
            await _reportRepository.RemoveReportAsync(reportId);
        }
    }
}
