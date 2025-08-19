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
        private readonly ITransactionsToGetTransactionsDtoMapper _transactionsToGetTransactionsDtoMapper;
        public TransactionService(
            ITransactionRepository transactionRepository,
            ITransactionCreationMapper transactionCreationMapper,
            ITransactionsToGetTransactionsDtoMapper transactionsToGetTransactionsDtoMapper)
        {
            _transactionRepository = transactionRepository;
            _transactionCreationMapper = transactionCreationMapper;
            _transactionsToGetTransactionsDtoMapper = transactionsToGetTransactionsDtoMapper;
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

        public async Task<List<GetTransactionsDto>> GetFilteredTransactionsAsync(int userId, TransactionsFilterParams filterParams)
        {
            var transactions = await _transactionRepository.GetTransactionsByFilterAsync(filterParams, userId);

            var result = await _transactionsToGetTransactionsDtoMapper.Map(transactions);

            return result;
        }

        public async Task<List<GetTransactionsDto>> GetTransactionsAsync(int userId)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserIdAsync(userId);

            var result = await _transactionsToGetTransactionsDtoMapper.Map(transactions);

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
