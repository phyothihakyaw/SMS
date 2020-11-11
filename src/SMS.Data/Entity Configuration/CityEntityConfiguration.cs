using SMS.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace SMS.Data.Entity_Configuration
{
    public class CityEntityConfiguration : EntityTypeConfiguration<City>
    {
        public CityEntityConfiguration()
        {
            this.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(c => c.CreatedUserId)
                .IsRequired();

            this.Property(c => c.UpdatedUserId)
                .IsRequired();
        }
    }
}
