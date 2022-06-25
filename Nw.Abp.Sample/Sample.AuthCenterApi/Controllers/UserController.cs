using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.IApplication.UseService;
using Sample.IApplication.UseService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.AuthCenterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
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
