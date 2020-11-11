using SMS.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace SMS.Data.Entity_Configuration
{
    public class BranchEntityConfiguration : EntityTypeConfiguration<Branch>
    {
        public BranchEntityConfiguration()
        {
            this.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(b => b.FullAddress)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(b => b.PhoneNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(b => b.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(b => b.CreatedUserId)
                .IsRequired();

            this.Property(b => b.UpdatedUserId)
                .IsRequired();
        }
    }
}
