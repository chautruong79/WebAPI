using System;
using System.Collections.Generic;
using System.Text;
using Ex4.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ex4.Configurations
{
    class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock");
            builder.HasKey(s => s.StockID);
            builder.Property(p => p.StockName)
                    .HasMaxLength(20);
            builder.Property(p => p.CalculationUnit)
                    .HasMaxLength(10);
            builder.HasOne(c => c.StockType)
                .WithMany(p => p.Stocks)
                .HasForeignKey(c => c.StockTypeID);
            //builder.HasData(
            //    new Stock() { StockID = 1, StockName = "Glass", Price = 30.33, StockQuantity = 500, StockTypeID = 1 },
            //    new Stock() { StockID = 2, StockName = "Filter", Price = 55.4, StockQuantity = 500, StockTypeID = 1 },
            //    new Stock() { StockID = 3, StockName = "Wheel", Price = 155.4, StockQuantity = 500, StockTypeID = 1 },
            //    new Stock() { StockID = 4, StockName = "Shoes",Price = 58.5,StockQuantity= 500, StockTypeID = 2 },
            //    new Stock() { StockID = 5, StockName = "Jewelry",Price =1055,StockQuantity= 500, StockTypeID = 2 },
            //    new Stock() { StockID = 6, StockName = "HandBag",Price =234.4,StockQuantity= 500, StockTypeID = 2 },
            //    new Stock() { StockID = 7, StockName = "Camera",Price = 505.3,StockQuantity= 500, StockTypeID = 3 },
            //    new Stock() { StockID = 8, StockName = "SmartHome",Price = 200.2,StockQuantity= 500, StockTypeID = 3 },
            //    new Stock() { StockID = 9, StockName = "Laptop",Price = 1030.2,StockQuantity= 500, StockTypeID = 3 },
            //    new Stock() { StockID = 10, StockName = "Antique",Price =34.5,StockQuantity= 500, StockTypeID = 4 },
            //    new Stock() { StockID = 11, StockName = "Stamp",Price =2.4,StockQuantity= 500, StockTypeID = 4 },
            //    new Stock() { StockID = 12, StockName = "Pottery",Price =15.6,StockQuantity= 500, StockTypeID = 4 },
            //    new Stock() { StockID = 13, StockName = "Mattress",Price =705.2,StockQuantity= 500, StockTypeID = 5 },
            //    new Stock() { StockID = 14, StockName = "Cookware",Price =124.3,StockQuantity= 500, StockTypeID = 5 },
            //    new Stock() { StockID = 15, StockName = "Chair",Price =220.1,StockQuantity= 500, StockTypeID = 5 },
            //    new Stock() { StockID = 16, StockName = "Bike",Price = 139.9,StockQuantity= 500, StockTypeID = 6 },
            //    new Stock() { StockID = 17, StockName = "Golf Ball",Price = 7.5,StockQuantity= 500, StockTypeID = 6 },
            //    new Stock() { StockID = 18, StockName = "Tent",Price = 77.9,StockQuantity= 500, StockTypeID = 6 }
            //    //new Stock() { StockID = 19, StockName = "",Price =,StockQuantity= 500, StockTypeID = 1 },
            //    );
        }
    }
}
