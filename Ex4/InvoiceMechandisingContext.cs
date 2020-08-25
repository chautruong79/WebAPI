using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex4.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ex4
{
    class InvoiceMechandisingContext : DbContext
    {
        public InvoiceMechandisingContext(DbContextOptions<InvoiceMechandisingContext> options)
          : base(options)
        {
        }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
