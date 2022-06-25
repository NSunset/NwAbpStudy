using Sample.Application.UseService.Dtos;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Sample.Application.UseService
{
    public interface IUserAppService : IApplicationService
    {
        Task<LoginUserDto> Login(string name, string pwd);
    }
}
