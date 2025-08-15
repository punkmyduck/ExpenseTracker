using ExpenseTracker.DomainLayer.ExpenseTrackerDataModels;

namespace ExpenseTracker.ApplicationLayer.Repositories.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(Refreshtoken token, CancellationToken ct = default);
        Task<Refreshtoken?> GetByTokenAsync(string token, CancellationToken ct = default);
        Task InvalidateAsync(Refreshtoken token, CancellationToken ct = default);
    }
}
