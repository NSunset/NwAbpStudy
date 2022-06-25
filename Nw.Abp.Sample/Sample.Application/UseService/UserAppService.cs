using Microsoft.EntityFrameworkCore;
using Sample.Application.UseService.Dtos;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sample.Application.UseService
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IRepository<User> userRepository;

        public UserAppService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<LoginUserDto> Login(string name, string pwd)
        {
            var user = await userRepository.AsNoTracking().SingleOrDefaultAsync(a => a.Name == name && a.Password == pwd);

            var dto = ObjectMapper.Map<User, LoginUserDto>(user);
            return dto;
        }
    }
}
