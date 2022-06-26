using Microsoft.EntityFrameworkCore;
using Sample.Common;
using Sample.Common.JwtHelpers;
using Sample.Domain.Models;
using Sample.Domain.Users;
using Sample.IApplication.UseService;
using Sample.IApplication.UseService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Sample.Application.UseService
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IUserManager userManager;

        public UserAppService(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<LoginUserDto> GetLoginUserAsync()
        {
            var user = await userManager.GetLoginUserAsync();
            var dto = ObjectMapper.Map<User, LoginUserDto>(user);
            return dto;
        }
    }
}
