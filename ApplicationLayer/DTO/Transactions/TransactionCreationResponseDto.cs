namespace ExpenseTracker.ApplicationLayer.DTO.Transactions
{
    public class TransactionCreationResponseDto
    {
        public long TransactionId { get; set; }
        public char Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Commentary { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
