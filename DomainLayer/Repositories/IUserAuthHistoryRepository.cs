using ExpenseTracker.DomainLayer.Entities;

namespace ExpenseTracker.DomainLayer.Repositories
{
    public interface IUserAuthHistoryRepository
    {
        Task AddAsync(Userauthhistory userAuthHistory);
    }
}
