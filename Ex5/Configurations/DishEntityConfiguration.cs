using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex5.Configurations
{
    class DishEntityConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dish");
            builder.HasKey(s => s.DishID);
            builder.Property(p => p.DishName)
                    .HasMaxLength(20); 
            builder.Property(p => p.Introduction)
                  .HasMaxLength(100);
            builder.HasOne(c => c.DishType)
                .WithMany(p => p.Dishes)
                .HasForeignKey(c => c.DishTypeID);
            builder.HasData(
                new Dish() { DishID = 1, DishTypeID = 1, DishName = "Strawberry Bread", Introduction = "This is wonderful hot or cold, for breakfast or as a dessert. A definite family favorite!", Method = "", Price = 2.5},
                new Dish() { DishID = 2, DishTypeID = 1, DishName = "Hamburger Buns", Introduction = "They are so easy to make: light and fluffy as well as beautiful to look at. ", Method = "", Price = 1.7},
                new Dish() { DishID = 3, DishTypeID = 2, DishName = "Black Magic Cake", Introduction = "Super spooky dark chocolate cake. Suitable for all your black magic get-togethers.", Method = "", Price = 11.3},
                new Dish() { DishID = 4, DishTypeID = 2, DishName = "Plum Kuchen", Introduction = "Moist plum coffee cake with sugar and cinnamon crumble topping.", Method = "", Price = 7.6},
                new Dish() { DishID = 5, DishTypeID = 3, DishName = "Roasted Beet", Introduction = "Roasted beets with balsamic vinegar dressing.", Method = "", Price = 23.1},
                new Dish() { DishID = 6, DishTypeID = 3, DishName = "Mediterrane Chicken", Introduction = "Tender, boneless chicken breasts are marinated in sun dried tomato dressing.", Method = "", Price = 15.5},
                new Dish() { DishID = 7, DishTypeID = 4, DishName = "Fruit and Yogurt", Introduction = "This recipe is delicious! You may substitute the strawberries for any other berries or fruit.", Method = "", Price = 3.2},
                new Dish() { DishID = 8, DishTypeID = 4, DishName = "Kale Banana", Introduction = "So good! Great flavor and not too sweet. Very filling!", Method = "", Price = 4.9},
                new Dish() { DishID = 9, DishTypeID = 5, DishName = "Italian Ribollita", Introduction = "This hearty bread and vegetable soup is served 're-boiled,' as its Italian name indicates.", Method = "", Price = 17.8},
                new Dish() { DishID = 10, DishTypeID = 5, DishName = "Chicken Taco Soup", Introduction = "This cozy soup will be ready in 15 minutes. You can make it even quicker by using rotisserie chicken", Method = "", Price = 7.3}
                //new Dish() { DishID = 1, DishTypeID = , DishName = "", Introduction = "", Method = "", Price = },
                );
        }
    }
}
