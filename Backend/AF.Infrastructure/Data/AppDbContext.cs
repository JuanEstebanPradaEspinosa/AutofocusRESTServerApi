using AF.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AF.Infrastructure.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Lessor> Lessors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Relatie tussen User en cars + User and bookings
            //TODO:
            modelBuilder.Entity<Tenant>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.Id); // gebruikers-ID wordt geërfd van de User-klasse

            // Relatie tussen Lessor en User
            modelBuilder.Entity<Lessor>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.Id); // gebruikers-ID wordt geërfd van de User-klasse
        }
    }
}
