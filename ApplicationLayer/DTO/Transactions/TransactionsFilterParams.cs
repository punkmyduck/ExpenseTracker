using ExpenseTracker.DomainLayer.Enums;

namespace ExpenseTracker.ApplicationLayer.DTO.Transactions
{
    public class TransactionsFilterParams
    {
        public DateTime StartDateTime { get; set; } = DateTime.MinValue;
        public DateTime EndDateTime { get; set; } = DateTime.MaxValue;
        public TransactionType? TransactionType { get; set; }
        public int? CategoryId { get; set; }
    }
}
