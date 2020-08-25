using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex4.Entities;
using Ex4.IRepository;

namespace Ex4.Repository
{
    class StockRepository : BaseRepository<Stock>, IStockRepository
    {
        private readonly InvoiceMechandisingContext _context;

        public StockRepository(InvoiceMechandisingContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Stock entity)
        {
            _context.Update(entity);
        }
    }
}
