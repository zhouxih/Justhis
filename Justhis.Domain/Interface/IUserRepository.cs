using Justhis.Domain.Models;
using Justhis.InfrastructureCommon;

namespace Justhis.Domain.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByPhone(string phoneNumber);
    }
}
