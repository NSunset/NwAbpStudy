using Sample.Common.JwtHelpers;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Users
{
    public interface IUserManager
    {
        JwtTokenModel GetToken(IEnumerable<Claim> claims);

        Task<User> GetLoginUserAsync();
    }
}
