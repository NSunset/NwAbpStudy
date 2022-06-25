using AutoMapper;
using Sample.Application.UseService.Dtos;
using Sample.Domain.Models;
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
