using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex5.Configurations
{
    class IngredientEntityConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredient");
            builder.HasKey(s => s.IngredientID);
            builder.Property(p => p.IngredientName)
                    .HasMaxLength(20);
            builder.Property(p => p.Note)
                  .HasMaxLength(100);
            builder.HasData(
                new Ingredient() { IngredientID = 1, IngredientName = "Milk", Note = "" },
                new Ingredient() { IngredientID = 2, IngredientName = "Sugar", Note = "" },
                new Ingredient() { IngredientID = 3, IngredientName = "Egg", Note = "" },
                new Ingredient() { IngredientID = 4, IngredientName = "Flour", Note = "" },
                new Ingredient() { IngredientID = 5, IngredientName = "Fruit", Note = "" }
                //new Ingredient() { IngredientID = 1, IngredientName = "", Note = "" },
                );    
        }
    }
}
