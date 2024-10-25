using Justhis.Application.Interfaces;
using Justhis.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Justhis.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserAppService userAppService;
        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers() 
        {
            var users =  await userAppService.GetAll();
            return users;
        }


    }
}
