using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoCanvas.Domain.Entities;

namespace CoCanvas.Infrastructure.Persistance
{
    public class CCDbContext : DbContext
    {

        public CCDbContext(DbContextOptions<CCDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> SampleUsers { get; set; }
    }
}
