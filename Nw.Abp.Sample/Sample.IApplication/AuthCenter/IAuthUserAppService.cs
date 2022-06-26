using Sample.IApplication.AuthCenter.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Sample.IApplication.AuthCenter
{
    public interface IAuthUserAppService : IApplicationService
    {
        Task<LoginResultDto> LoginAsync(LoginInputDto loginInput);
    }
}
