using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
    }
}
