using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex5.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ex5
{
    class RecipeCookwareContext : DbContext
    {
        public RecipeCookwareContext(DbContextOptions<RecipeCookwareContext> options)
          : base(options)
        {
        }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
