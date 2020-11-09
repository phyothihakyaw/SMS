using Microsoft.AspNet.Identity.EntityFramework;
using SMS.Data.Entity_Configuration;
using System.Data.Entity;

namespace SMS.Data.Models
{
    public class SMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<City> Cities { get; set; }

        public SMSDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static SMSDbContext Create()
        {
            return new SMSDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
