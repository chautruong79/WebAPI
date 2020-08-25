using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex5.Configurations
{
    class DishTypeEntityConfiguration :  IEntityTypeConfiguration<DishType>
    {
        public void Configure(EntityTypeBuilder<DishType> builder)
        {
            builder.ToTable("DishType");
            builder.HasKey(s => s.DishTypeID);
            builder.Property(p => p.DishTypeName)
                   .HasMaxLength(20);
            builder.Property(p => p.Description)
                    .HasMaxLength(100);
            builder.HasData(
                new DishType() { DishTypeID = 1, DishTypeName = "Breads", Description = "See how to make bread at home." },
                new DishType() { DishTypeID = 2, DishTypeName = "Cakes", Description = "See the best cake recipes." },
                new DishType() { DishTypeID = 3, DishTypeName = "Salads", Description = "Find the best green salad recipes." },
                new DishType() { DishTypeID = 4, DishTypeName = "Smoothies", Description = "Banana, strawberry, and dozens more fruit and vegetable smoothie recipes." },
                new DishType() { DishTypeID = 5, DishTypeName = "Soups & Stews", Description = "Find recipes for hearty favorites." }
                );           
        }
    }
}
