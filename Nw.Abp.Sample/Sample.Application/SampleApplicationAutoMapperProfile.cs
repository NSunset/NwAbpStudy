using AutoMapper;
using Sample.Domain.Models;
using Sample.IApplication.UseService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application
{
    public class SampleApplicationAutoMapperProfile : Profile
    {
        public SampleApplicationAutoMapperProfile()
        {
            this.CreateMap<User, LoginUserDto>();
        }
    }
}
