using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coursework1.Models
{
    public class AppDataContext : IdentityDbContext<ApplicationUser>
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<PostModel> Post { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
