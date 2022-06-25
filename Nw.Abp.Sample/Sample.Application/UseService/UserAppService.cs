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
        private readonly IRepository<User> userRepository;
        private readonly IUserManager userManager;

        public UserAppService(IRepository<User> userRepository, IUserManager userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public async Task<LoginUserDto> GetLoginUserAsync()
        {
            var user = await userManager.GetLoginUserAsync();
            var dto = ObjectMapper.Map<User, LoginUserDto>(user);
            return dto;
        }

        public async Task<LoginResultDto> LoginAsync(LoginInputDto loginInput)
        {
            User user = await userRepository.AsNoTracking().SingleOrDefaultAsync(a => a.Name == loginInput.Name && a.Password == loginInput.Pwd);

            if (user == null)
                throw new UserException("登录失败,输入用户不存在");
            JwtTokenModel tokenModel = userManager.GetToken(user.GetClaims());

            return new LoginResultDto
            {
                Token = tokenModel.Token
            };
        }
    }
}
