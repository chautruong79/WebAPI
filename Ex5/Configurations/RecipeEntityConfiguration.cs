using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex5.Configurations
{
    class RecipeEntityConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipe");
            builder.HasKey(s => s.RecipeID);
            builder.Property(p => p.CalculationUnit)
                    .HasMaxLength(10);
            builder.HasOne(c => c.Dish)
                .WithMany(p => p.Recipes)
                .HasForeignKey(c => c.DishID);
            builder.HasOne(c => c.Ingredient)
                .WithMany(p => p.Recipes)
                .HasForeignKey(c => c.IngredientID);
            //builder.HasData(
            //    new StockType() { StockTypeID = 1, StockTypeName = "Motors", Description = "Motors is where you will find new and used vehicles as well as parts for fixing, updating, or maintaining your existing vehicle. eBay Motors is easy to navigate by vehicle type, category of items, sales and events, or brand and type of car, motorcycle, pickup, or SUV." },
            //    new StockType() { StockTypeID = 2, StockTypeName = "Fashion", Description = "Take the strain out of shopping with us. Find great deals on classy clothing, stylish shoes, haute handbags, and jazzy jewelry. There are fashions and accessories for men, women, children, and babies so start shopping now." },
            //    new StockType() { StockTypeID = 3, StockTypeName = "Electronics", Description = "From smartphones and laptops to TVs and Nintendo Switch. This console functions as a portable handheld system, but you can also place it in a dock to enjoy HD gameplay at home. The detachable Joy-Con controllers work as regular controllers or through motion control, and as there are two, you can invite a friend to experience some face-to-face multiplayer action. Its a great console for busy gamers who need to take every chance possible to switch up their schedule and slot in some game time." },
            //    new StockType() { StockTypeID = 4, StockTypeName = "Collectibles & Art", Description = "Whether you collect antiques, rare coins, art collectibles, sports memorabilia or collectible toys, eBay offers an extensive and ever-evolving selection from which to choose. Browse a huge variety of categories from your computer, and snag that rare pinball machine or Montblanc fountain pen without leaving the comfort of your couch." },
            //    new StockType() { StockTypeID = 5, StockTypeName = "Home & Garden", Description = "When it comes to home improvement, look no further than the home and garden pages of eBay. A wide range of home goods from generators to rugs to furniture and bedding, are just a mouse click away. You’ll find everything you need in and around your home to make it uniquely your own." },
            //    new StockType() { StockTypeID = 6, StockTypeName = "Sporting Goods", Description = "Are you ready to play like a pro? No matter what your favorite sport is, we has the equipment you need to perform at your peak. Whether you want to try bowling for the first time or find inner peace during a relaxing yoga session, we offer sporting goods and equipment for all occasions and skill levels." },
            //    new StockType() { StockTypeID = 7, StockTypeName = "Toys", Description = "From the ages of 1 to 101, toys and games make the perfect gift. Whether you’re looking for shape sorters and wooden blocks to help your child hone fine motor control, or you need a sassy, fun board game for your cocktail party, toys and games can turn an everyday moment into a magical one to remember. With a wide selection of rare, retro and “right now” toys, we has everything you need for birthdays, holidays, special occasions and those “just because” times." },
            //    new StockType() { StockTypeID = 8, StockTypeName = "Business & Industry", Description = "Whether you are in construction or catering, welding or wedding planning, sellers on eBay have all the business and industrial products your company needs to thrive." }
            //    );        }     
        }
    }
}
