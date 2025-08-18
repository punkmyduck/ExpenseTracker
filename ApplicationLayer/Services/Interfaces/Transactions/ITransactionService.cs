using ExpenseTracker.ApplicationLayer.DTO.Transactions;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Transactions
{
    public interface ITransactionService
    {
        Task<List<GetTransactionsDto>> GetTransactionsAsync(int userId);
        Task<TransactionCreationResponseDto> CreateTransactionAsync(int userId, TransactionCreationRequestDto transactionCreationDto);
        Task RemoveTransactionAsync(int userId, int transactionId);
        Task UpdateTransactionAsync(int userId, UpdateTransactionDto updateTransactionDto);
    }
}
