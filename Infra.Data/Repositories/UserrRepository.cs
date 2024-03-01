using Domain.Entities;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserrRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserrRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
