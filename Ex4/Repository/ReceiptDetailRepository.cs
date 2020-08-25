using System;
using System.Collections.Generic;
using System.Text;
using Ex4.Entities;
using Ex4.IRepository;

namespace Ex4.Repository
{
    class ReceiptDetailRepository : BaseRepository<ReceiptDetail>, IReceiptDetailRepository
    {
        private readonly InvoiceMechandisingContext _context;

        public ReceiptDetailRepository(InvoiceMechandisingContext context) : base(context)
        {
            _context = context;
        }
    }
}
