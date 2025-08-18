using ExpenseTracker.ApplicationLayer.DTO.Reports;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task RemoveReportAsync(int reportId)
        {
            await _context.Reports.Where(r => r.Reportid == reportId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<List<Report>> GetReportsByUserIdAsync(int userId)
        {
            return await _context.Reports.AsNoTracking().Where(r=>r.Userid == userId).ToListAsync();
        }

        public async Task<Report?> GetReportByIdAsync(int reportId)
        {
            return await _context.Reports.AsNoTracking().FirstOrDefaultAsync(r=>r.Reportid == reportId);
        }

        public async Task<bool> CheckReportsPermissionAsync(int reportId, int userId)
        {
            var report = await GetReportByIdAsync(reportId);
            if (report == null)
            {
                throw new KeyNotFoundException("Report not found.");
            }
            if (report.Userid != userId)
            {
                return false;
            }
            return true;
        }
    }
}
