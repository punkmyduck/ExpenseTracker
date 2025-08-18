using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.ApplicationLayer.Mapping;
using ExpenseTracker.ApplicationLayer.Services.Interfaces.Transactions;
using ExpenseTracker.DomainLayer.Enums;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionCreationMapper _transactionCreationMapper;
        public TransactionService(
            ITransactionRepository transactionRepository,
            ITransactionCreationMapper transactionCreationMapper)
        {
            _transactionRepository = transactionRepository;
            _transactionCreationMapper = transactionCreationMapper;
        }
        public async Task<TransactionCreationResponseDto> CreateTransactionAsync(int userId, TransactionCreationRequestDto transactionCreationDto)
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

        public async Task<List<GetTransactionsDto>> GetTransactionsAsync(int userId)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserIdAsync(userId);

            List<GetTransactionsDto> result = new();

            foreach (var t in transactions)
            {
                result.Add(new GetTransactionsDto
                {
                    TransactionId = t.Transactionid,
                    TransactionType = t.Type == 'I' ? TransactionType.Income : TransactionType.Expense,
                    Amount = t.Amount,
                    Date = t.Date,
                    Commentary = t.Commentary,
                    CategoryId = t.Categoryid
                });
            }

            return result;
        }

        public async Task RemoveTransactionAsync(int userId, int transactionId)
        {
            if (!await _transactionRepository.CheckTransactionPermission(transactionId, userId))
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this transaction.");
            }
            await _transactionRepository.RemoveTransactionAsync(transactionId);
        }

        public async Task UpdateTransactionAsync(int userId, UpdateTransactionDto updateTransactionDto)
        {
            if (!await _transactionRepository.CheckTransactionPermission(updateTransactionDto.TransactionId, userId))
            {
                throw new UnauthorizedAccessException("You do not have permission to delete this transaction.");
            }

            await _transactionRepository.UpdateTransactionAsync(updateTransactionDto, userId);
        }
    }
}
