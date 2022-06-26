using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Sample.Domain.Models
{
    public class User : Entity<int>
    {
        public string Name { get; set; }

        public string Password { get; set; }


        public IEnumerable<Claim> GetClaims()
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name,Name),
                new Claim(nameof(Id),Id.ToString())
            };
        }
    }
}
