using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sample.Common;
using Sample.Common.JwtHelpers;
using Sample.Common.JwtHelpers.IServices;
using Sample.Domain.Models;
using Sample.IApplication.AuthCenter;
using Sample.IApplication.AuthCenter.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sample.Application.AuthCenter
{
    public class AuthUserAppService : ApplicationService, IAuthUserAppService
    {
        private readonly IRepository<User> userRepository;
        private readonly IJwtService jwtService;

        public AuthUserAppService(IRepository<User> userRepository
            , IJwtService jwtService
            )
        {
            this.userRepository = userRepository;
            this.jwtService = jwtService;
        }
        public async Task<LoginResultDto> LoginAsync(LoginInputDto loginInput)
        {
            User user = await userRepository.AsNoTracking().SingleOrDefaultAsync(a => a.Name == loginInput.Name && a.Password == loginInput.Pwd);

            if (user == null)
                throw new UserException("登录失败,输入用户不存在");
            JwtTokenModel tokenModel = jwtService.GetToken(user.GetClaims());

            return new LoginResultDto
            {
                Token = tokenModel.Token
            };
        }
    }
}
