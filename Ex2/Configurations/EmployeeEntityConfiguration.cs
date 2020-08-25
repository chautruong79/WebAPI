using System;
using System.Collections.Generic;
using System.Text;
using Ex2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex2.Configurations
{
    class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.HasKey(s => s.EmployeeID);
            builder.Property(p => p.FullName)
                .HasMaxLength(20);
            builder.Property(p => p.DOB)
                   .HasColumnName("DateOfBirth")
                   .HasDefaultValueSql("GetDate()");
            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            builder.Property(p => p.Address)
                .HasMaxLength(50);
            builder.Property(p => p.Email)
                .HasMaxLength(20);
            builder.HasData(
               new Employee() { EmployeeID = 1, FullName = "A A", Address = "Hanoi", DOB = new DateTime(2001, 1, 1), PhoneNumber = "0912345678", Email = "a@yahoo.com", PayRate = 7 },
               new Employee() { EmployeeID = 2, FullName = "B B", Address = "Hanoi", DOB = new DateTime(2002, 1, 1), PhoneNumber = "0912345678", Email = "b@yahoo.com", PayRate = 12 },
                new Employee() { EmployeeID = 3, FullName = "C C", Address = "Hanoi", DOB = new DateTime(2003, 1, 1), PhoneNumber = "0912345678", Email = "c@yahoo.com", PayRate = (float?)10.5 },
                new Employee() { EmployeeID = 4, FullName = "D D", Address = "Hanoi", DOB = new DateTime(2004, 1, 1), PhoneNumber = "0912345678", Email = "d@yahoo.com", PayRate = (float?)5.4 }
                );
        }
    }
}
