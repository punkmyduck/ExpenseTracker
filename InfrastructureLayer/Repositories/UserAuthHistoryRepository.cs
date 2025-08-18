using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class UserAuthHistoryRepository : IUserAuthHistoryRepository
    {
        private readonly ExpenseTrackerContext _context;
        public UserAuthHistoryRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Userauthhistory userAuthHistory)
        {
            await _context.Userauthhistories.AddAsync(userAuthHistory);
            await _context.SaveChangesAsync();
        }
    }
}
