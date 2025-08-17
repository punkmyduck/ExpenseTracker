using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface ITransactionRepository
    {
        Task CreateTransactionAsync(Transaction transaction);
    }
}
