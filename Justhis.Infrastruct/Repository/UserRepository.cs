using Justhis.Domain.Interface;
using Justhis.Domain.Models;
using Justhis.InfrastructServiceCommom;
using Microsoft.EntityFrameworkCore;

namespace Justhis.Infrastruct.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext db, DbSet<User> dbSet) : base(db, dbSet)
        {

        }

        public async Task<User> GetByPhone(string phoneNumber)
        {
            var user = await DbSet.FirstOrDefaultAsync(user => user.Phone == phoneNumber);
            return user;
        }
    }
}
