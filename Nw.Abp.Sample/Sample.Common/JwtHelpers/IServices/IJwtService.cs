using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Common.JwtHelpers.IServices
{
    public interface IJwtService
    {
        public JwtTokenModel GetToken(IEnumerable<Claim> claims);
    }
}
