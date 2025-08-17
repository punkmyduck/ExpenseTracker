using ExpenseTracker.ApplicationLayer.Services.Interfaces;
using ExpenseTracker.DomainLayer.Entities;
using ExpenseTracker.DomainLayer.Repositories;

namespace ExpenseTracker.ApplicationLayer.Services.Implementations
{
    public class CurrentUserProfileService : ICurrentUserProfileService
    {
        private readonly IUserRepository _userRepository;
        public CurrentUserProfileService(
            IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetCurrentUserAsync(int userId)
        {
            return await _userRepository.GetById(userId);
        }
    }
}
