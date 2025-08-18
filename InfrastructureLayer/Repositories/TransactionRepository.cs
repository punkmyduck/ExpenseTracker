using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;

namespace ExpenseTracker.InfrastructureLayer.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ExpenseTrackerContext _context;
        public TransactionRepository(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
