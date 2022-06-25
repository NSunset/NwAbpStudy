using Sample.IApplication.UseService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Sample.IApplication.UseService
{
    public interface IUserAppService : IApplicationService
    {
        Task<LoginResultDto> LoginAsync(LoginInputDto loginInput);

        Task<LoginUserDto> GetLoginUserAsync();
    }
}
