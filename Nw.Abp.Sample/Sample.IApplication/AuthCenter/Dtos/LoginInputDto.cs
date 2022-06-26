using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Sample.IApplication.AuthCenter.Dtos
{
    public class LoginInputDto
    {
        public string Name { get; set; }

        public string Pwd { get; set; }
    }
}
