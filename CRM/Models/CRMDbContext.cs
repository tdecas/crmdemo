using System.Data.Entity;

namespace CRM.Models
{
    public class CRMDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}