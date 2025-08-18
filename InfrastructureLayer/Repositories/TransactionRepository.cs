using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Enums;
using ExpenseTracker.DomainLayer.Repositories;
using ExpenseTracker.InfrastructureLayer.Persistence;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> CheckTransactionPermission(int transactionId, int userId)
        {
            var transaction = await GetTransactionByIdAsync(transactionId);
            if (transaction == null)
            {
                throw new KeyNotFoundException("Transaction not found.");
            }
            if (transaction.Userid != userId)
            {
                return false;
            }
            return true;
        }

        public async Task<Transaction?> GetTransactionByIdAsync(int transactionId)
        {
            return await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(t => t.Transactionid == transactionId);
        }

        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(int userId)
        {
            return await _context.Transactions.AsNoTracking().Where(t => t.Userid == userId).ToListAsync();
        }

        public async Task RemoveTransactionAsync(int transactionId)
        {
            await _context.Transactions.Where(t => t.Transactionid == transactionId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransactionAsync(UpdateTransactionDto dto, int userId)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Transactionid == dto.TransactionId && t.Userid == userId);
            if (transaction == null) throw new KeyNotFoundException("Transaction not found");

            transaction.Type = dto.Type.HasValue ? MapTransactionType(dto.Type.Value) : transaction.Type;
            transaction.Amount = dto.Amount ?? transaction.Amount;
            transaction.Date = dto.DateTime ?? transaction.Date;
            transaction.Commentary = dto.Commentary ?? transaction.Commentary;
            transaction.Categoryid = dto.CategoryId ?? transaction.Categoryid;

            await _context.SaveChangesAsync();
        }

        private static char MapTransactionType(TransactionType type)
        {
            return type switch
            {
                TransactionType.Income => 'I',
                TransactionType.Expense => 'E',
                _ => throw new ArgumentOutOfRangeException(nameof(type), "Unknown transaction type")
            };
        }

        public async Task<List<Transaction>> GetTransactionsByFilterAsync(TransactionsFilterParams filterParams, int userId)
        {
            var query = _context.Transactions.AsQueryable();

            query = query.Where(t => t.Userid == userId &&
                                     t.Date >= filterParams.StartDateTime &&
                                     t.Date <= filterParams.EndDateTime);

            if (filterParams.CategoryId.HasValue)
                query = query.Where(t => t.Categoryid == filterParams.CategoryId.Value);

            if (filterParams.TransactionType.HasValue)
                query = query.Where(t => t.Type == (char)filterParams.TransactionType.Value);

            return await query.ToListAsync();
        }
    }
}
