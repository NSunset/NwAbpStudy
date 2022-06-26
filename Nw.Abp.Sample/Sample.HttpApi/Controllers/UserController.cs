using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RedisHelper.Interface;
using RedisHelper.Service;
using Sample.Common.Redis;
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
        private readonly RedisStringService stringService;

        public UserController(IUserAppService userAppService
            , RedisHelper.Service.RedisStringService stringService
            )
        {
            this.userAppService = userAppService;
            this.stringService = stringService;
        }

        [Route("GetNum")]
        [HttpGet]
        public async Task<int> RedisGetNumber(int num)
        {
            //stringService.SetDb(2);
            int value = await stringService.GetAsync<int>("testNum");
            if (value == 0)
            {
                await stringService.SetAsync<int>("testNum", num, TimeSpan.FromMinutes(5));
                value = num;
            }
            return value;
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
