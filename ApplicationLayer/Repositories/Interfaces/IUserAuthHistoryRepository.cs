using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Repositories.Interfaces
{
    public interface IUserAuthHistoryRepository
    {
        Task AddAsync(Userauthhistory userAuthHistory);
    }
}
