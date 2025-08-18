using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ExpenseTrackerContext _context;
        public ReportRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task AddReportAsync(Report report)
        {
            await _context.AddAsync(report);
            await _context.SaveChangesAsync();
        }
    }
}
