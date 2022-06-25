using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sample.Common;
using Sample.Common.JwtHelpers;
using Sample.Common.JwtHelpers.IServices;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Sample.Domain.Users
{
    public class UserManager : IUserManager, ITransientDependency
    {
        private readonly IJwtService jwtService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRepository<User> userRepository;

        public UserManager(IJwtService jwtService
            , IHttpContextAccessor httpContextAccessor
            , IRepository<User> userRepository
            )
        {
            this.jwtService = jwtService;
            this.httpContextAccessor = httpContextAccessor;
            this.userRepository = userRepository;
        }

        public async Task<User> GetLoginUserAsync()
        {
            var userId = httpContextAccessor.HttpContext?.User?.Claims?
                .SingleOrDefault(a => a.Type == "CurrentId")?.Value;

            if (userId == null)
            {
                throw new UserException("未找到登录用户信息，请通知后台检查");
            }
            int uid = Convert.ToInt32(userId);
            return await userRepository.FindAsync(u => u.Id == uid);
        }

        public JwtTokenModel GetToken(IEnumerable<Claim> claims)
        {
            return jwtService.GetToken(claims);
        }
    }
}
