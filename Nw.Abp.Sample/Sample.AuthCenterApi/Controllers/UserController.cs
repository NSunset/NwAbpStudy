using Microsoft.AspNetCore.Mvc;
using Sample.IApplication.AuthCenter;
using Sample.IApplication.AuthCenter.Dtos;
using System.Threading.Tasks;

namespace Sample.AuthCenterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthUserAppService userAppService;

        public UserController(IAuthUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<LoginResultDto> Login(LoginInputDto loginInput)
        {
            return await userAppService.LoginAsync(loginInput);
        }
    }
}
