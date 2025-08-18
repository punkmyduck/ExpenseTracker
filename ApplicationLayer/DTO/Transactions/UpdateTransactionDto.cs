using ExpenseTracker.DomainLayer.Enums;

namespace ExpenseTracker.ApplicationLayer.DTO.Transactions
{
    public class UpdateTransactionDto
    {
        public int TransactionId { get; set; }
        public TransactionType? Type { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Commentary { get; set; }
        public int? CategoryId { get; set; }
    }
}
