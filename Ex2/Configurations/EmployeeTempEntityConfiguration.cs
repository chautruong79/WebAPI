using System;
using System.Collections.Generic;
using System.Text;
using Ex2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex2.Configurations
{
    class EmployeeTempEntityConfiguration : IEntityTypeConfiguration<EmployeeTemp>
    {
        public void Configure(EntityTypeBuilder<EmployeeTemp> builder)
        {
            builder.ToTable("EmployeeTemp");
            builder.HasKey(s => s.EmployeeTempID);
        }
    }
}
