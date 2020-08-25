using System;
using System.Collections.Generic;
using System.Text;
using Ex4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex4.Configurations
{
    class ReceiptEntityConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            builder.ToTable("Receipt");
            builder.HasKey(s => s.ReceiptID);
            builder.Property(p => p.DateCreated)
                .HasDefaultValueSql("GetDate()");
            builder.Property(p => p.StaffCreated)
                    .HasMaxLength(20);
            builder.Property(p => p.Note)
                    .HasMaxLength(100);
        }
    }
}
