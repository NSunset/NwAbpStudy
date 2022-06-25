using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.UseService;
using Sample.Application.UseService.Dtos;
using Sample.Domain.Models;
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

        [Route("Login")]
        [HttpPost]
        public async Task<LoginUserDto> Login(string name,string pwd)
        {
            return await userAppService.Login(name, pwd);
        }
    }
}
