using ExpenseTracker.ApplicationLayer.DTO.Transactions;

namespace ExpenseTracker.ApplicationLayer.Services.Interfaces.Transactions
{
    public interface ITransactionCreatorService
    {
        Task<TransactionCreationResponseDto> CreateTransaction(int userId, TransactionCreationRequestDto transactionCreationDto);
    }
}
