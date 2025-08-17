namespace ExpenseTracker.ApplicationLayer.DTO.Categories
{
    public class GetUserCategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int UserId { get; set; }
    }
}
