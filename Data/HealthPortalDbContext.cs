using Microsoft.EntityFrameworkCore;
using HealthPortalAPI.Models;

namespace HealthPortalAPI.Data
{
    public class HealthPortalDbContext : DbContext
    {
        public HealthPortalDbContext(DbContextOptions<HealthPortalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
