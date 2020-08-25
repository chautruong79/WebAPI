using System;
using System.Collections.Generic;
using System.Text;
using Ex4.Entities;
using Ex4.IRepository;

namespace Ex4.Repository
{
    class StockTypeRepository : BaseRepository<StockType>, IStockTypeRepository
    {
        private readonly InvoiceMechandisingContext _context;

        public StockTypeRepository(InvoiceMechandisingContext context) : base(context)
        {
            _context = context;
        }
    }
}
