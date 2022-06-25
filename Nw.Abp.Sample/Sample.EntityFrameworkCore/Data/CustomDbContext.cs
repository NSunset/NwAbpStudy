using Microsoft.EntityFrameworkCore;
using Sample.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.EntityFrameworkCore.Data
{
    [ConnectionStringName("Default")]
    public class CustomDbContext : AbpDbContext<CustomDbContext>
    {   
        public DbSet<User> User { get; set; }

        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
        {

        }
    }
}
