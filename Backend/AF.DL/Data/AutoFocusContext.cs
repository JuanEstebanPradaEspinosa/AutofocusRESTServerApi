using AF.DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DL.Data
{
    public class AutoFocusContext : DbContext
    {
        public AutoFocusContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=AutoFocus;User ID=sa;Password=ZwarteRidder007;Trust Server Certificate=True"); // , b => b.MigrationsAssembly("AutoFocus.Infrastructure")
        }
    }
}
