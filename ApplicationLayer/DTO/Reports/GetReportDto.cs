namespace ExpenseTracker.ApplicationLayer.DTO.Reports
{
    public class GetReportDto
    {
        public int ReportId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal TotalSum { get; set; }
        public int UserId { get; set; }
    }
}
