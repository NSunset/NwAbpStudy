using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Sample.Domain.Models
{
    public class User : Entity<int>
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
