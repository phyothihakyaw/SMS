using SMS.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace SMS.Data.Entity_Configuration
{
    public class CityEntityConfiguration : EntityTypeConfiguration<City>
    {
        public CityEntityConfiguration()
        {
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.CreatedUserId)
                .IsRequired();

            this.Property(p => p.UpdatedUserId)
                .IsRequired();
        }
    }
}
