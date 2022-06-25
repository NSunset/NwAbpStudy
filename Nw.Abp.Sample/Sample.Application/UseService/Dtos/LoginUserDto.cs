using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.Application.UseService.Dtos
{
    public class LoginUserDto : EntityDto<int>
    {
        public string Name { get; set; }
    }
}
