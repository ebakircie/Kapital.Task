using Kapital.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Kapital.Infrastructure.Context
{
    public class KapitalContext : DbContext
    {
        public KapitalContext(DbContextOptions options) : base(options) {}

        public DbSet<Booking> bookings { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Apartment> appartments { get; set; }
    }
}
