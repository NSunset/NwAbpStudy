using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.IApplication.UseService;
using Sample.IApplication.UseService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.HttpApi.Controllers
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

        [Authorize]
        [Route("CurrentUser")]
        [HttpGet]
        public async Task<LoginUserDto> GetLoginUser()
        {
            return await userAppService.GetLoginUserAsync();
        }
    }
}
