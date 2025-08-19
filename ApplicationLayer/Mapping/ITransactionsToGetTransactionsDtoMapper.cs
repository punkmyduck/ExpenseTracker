using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public interface ITransactionsToGetTransactionsDtoMapper
    {
        Task<List<GetTransactionsDto>> Map(List<Transaction> transactions);
    }
}
