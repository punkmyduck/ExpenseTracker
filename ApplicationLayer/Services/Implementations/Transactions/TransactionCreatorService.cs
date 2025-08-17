using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.ApplicationLayer.Mapping;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Transactions;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.Transactions
{
    public class TransactionCreatorService : ITransactionCreatorService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionCreationMapper _transactionCreationMapper;
        public TransactionCreatorService(
            ITransactionRepository transactionRepository,
            ITransactionCreationMapper transactionCreationMapper)
        {
            _transactionRepository = transactionRepository;
            _transactionCreationMapper = transactionCreationMapper;
        }
        public async Task<TransactionCreationResponseDto> CreateTransaction(int userId, TransactionCreationRequestDto transactionCreationDto)
        {
            var transaction = await _transactionCreationMapper.Map(transactionCreationDto, userId);
            await _transactionRepository.AddTransactionAsync(transaction);
            return new TransactionCreationResponseDto{
                TransactionId = transaction.Transactionid,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Commentary = transaction.Commentary,
                CategoryId = transaction.Categoryid,
                UserId = transaction.Userid
            };
        }
    }
}
