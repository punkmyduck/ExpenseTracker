using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Exceptions;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public class TransactionCreationMapper : ITransactionCreationMapper
    {
        public Task<Transaction> Map(TransactionCreationRequestDto transactionCreationDto, int userId)
        {
            if (transactionCreationDto.Type == null)
            {
                throw new ValidationException("Transaction type is required.");
            }
            if (transactionCreationDto.Amount <= 0)
            {
                throw new ValidationException("Transaction amount must be greater than zero.");
            }

            Transaction transaction = new Transaction
            {
                Type = (char)transactionCreationDto.Type,
                Amount = transactionCreationDto.Amount,
                Date = transactionCreationDto.DateTime ?? DateTime.Now,
                Commentary = transactionCreationDto.Commentary,
                Categoryid = transactionCreationDto.CategoryId ?? 0,
                Userid = userId
            };

            return Task.FromResult(transaction);
        }
    }
}
