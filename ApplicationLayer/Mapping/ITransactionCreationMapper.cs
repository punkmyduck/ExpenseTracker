using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public interface ITransactionCreationMapper
    {
        Task<Transaction> Map(TransactionCreationRequestDto transactionCreationRequestDto, int userId);
    }
}
