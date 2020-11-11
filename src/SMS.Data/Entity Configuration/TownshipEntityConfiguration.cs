﻿using SMS.Data.Models;
using System.Data.Entity.ModelConfiguration;

namespace SMS.Data.Entity_Configuration
{
    public class TownshipEntityConfiguration : EntityTypeConfiguration<Township>
    {
        public TownshipEntityConfiguration()
        {
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
