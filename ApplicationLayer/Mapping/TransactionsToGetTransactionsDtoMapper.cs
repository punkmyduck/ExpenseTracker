using ExpenseTracker.ApplicationLayer.DTO.Transactions;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Enums;

namespace ExpenseTracker.ApplicationLayer.Mapping
{
    public class TransactionsToGetTransactionsDtoMapper : ITransactionsToGetTransactionsDtoMapper
    {
        public Task<List<GetTransactionsDto>> Map(List<Transaction> transactions)
        {
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
            return Task.FromResult(result);
        }
    }
}
