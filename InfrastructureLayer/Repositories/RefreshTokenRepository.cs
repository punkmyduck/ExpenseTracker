using ExpenseTracker.ApplicationLayer.Repositories.Interfaces;
using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ExpenseTrackerContext _context;

        public RefreshTokenRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Refreshtoken token, CancellationToken ct = default)
        {
            await _context.Set<Refreshtoken>().AddAsync(token, ct);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<Refreshtoken?> GetByTokenAsync(string token, CancellationToken ct = default)
        {
            return await _context.Set<Refreshtoken>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Token == token, ct);
        }

        public async Task InvalidateAsync(Refreshtoken token, CancellationToken ct = default)
        {
            token.Revokedat = DateTime.UtcNow;
            _context.Set<Refreshtoken>().Update(token);
            await _context.SaveChangesAsync(ct);
        }
    }
}
