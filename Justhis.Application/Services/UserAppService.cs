using Justhis.Application.Interfaces;
using Justhis.Domain.Interface;
using Justhis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justhis.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository userRepository;
        public UserAppService() { }
        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await userRepository.GetAllAsync();
            return users;
        }
    }
}
