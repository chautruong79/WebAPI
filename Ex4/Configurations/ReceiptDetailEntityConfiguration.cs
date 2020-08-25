using System;
using System.Collections.Generic;
using System.Text;
using Ex4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex4.Configurations
{
    class ReceiptDetailEntityConfiguration : IEntityTypeConfiguration<ReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<ReceiptDetail> builder)
        {
            builder.ToTable("ReceiptDetail");
            builder.HasKey(s => s.ReceiptDetailID);
            builder.HasOne(c => c.Stock)
                .WithMany(c => c.ReceiptDetails)
                .HasForeignKey(c => c.StockID);
            builder.HasOne(c => c.Receipt)
                .WithMany(c => c.ReceiptDetails)
                .HasForeignKey(c => c.ReceiptID);
        }
    }
}
