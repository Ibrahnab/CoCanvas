using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoCanvas.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CoCanvas.Infrastructure.Persistance
{
    public class CCDbContext : IdentityDbContext<User>
    {

        public CCDbContext(DbContextOptions<CCDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Property(u => u.Initials).HasMaxLength(5);

            builder.HasDefaultSchema("identity");

        }
    }
}
