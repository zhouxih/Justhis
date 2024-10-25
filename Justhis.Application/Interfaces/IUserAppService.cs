using Justhis.Domain.Models;

namespace Justhis.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<IEnumerable<User>> GetAll();
    }
}
