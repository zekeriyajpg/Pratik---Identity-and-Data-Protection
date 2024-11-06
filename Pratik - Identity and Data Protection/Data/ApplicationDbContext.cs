using Pratik___Identity_and_Data_Protection.Models;
using System.Collections.Generic;

namespace Pratik___Identity_and_Data_Protection.Data
{
    public class ApplicationDbContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; } // User tablosu
        }
    }
}
