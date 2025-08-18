using ExpenseTracker.DomainLayer.Enums;

namespace ExpenseTracker.ApplicationLayer.DTO.Transactions
{
    public class GetTransactionsDto
    {
        public long TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Commentary { get; set; }
        public int CategoryId { get; set; }
    }
}
