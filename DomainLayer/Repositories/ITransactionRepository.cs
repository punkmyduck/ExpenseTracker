using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId);
        Task<Transaction?> GetTransactionByIdAsync(int transactionId);
        Task<List<Transaction>> GetTransactionsByFilterAsync(TransactionsFilterParams filterParams, int userId);
        Task AddTransactionAsync(Transaction transaction);
        Task RemoveTransactionAsync(int transactionId);
        Task UpdateTransactionAsync(UpdateTransactionDto dto, int userId);
        Task<bool> CheckTransactionPermission(int transactionId, int userId);
    }
}
