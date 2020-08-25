using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex4.IRepository;

namespace Ex4.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly InvoiceMechandisingContext _context;
        private StockTypeRepository _stockTypes;
        private StockRepository _stocks;
        private ReceiptRepository _receipts;
        private ReceiptDetailRepository _receiptDetails;

        public UnitOfWork(InvoiceMechandisingContext context)
        {
            _context = context;
        }
        public IStockTypeRepository StockTypes => _stockTypes = _stockTypes ?? new StockTypeRepository(_context);

        public IStockRepository Stocks => _stocks = _stocks ?? new StockRepository(_context);

        public IReceiptRepository Receipts => _receipts = _receipts ?? new ReceiptRepository(_context);

        public IReceiptDetailRepository ReceiptDetails => _receiptDetails = _receiptDetails ?? new ReceiptDetailRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //public async Task RollbackAsync()
        //{
        //    await _context.DisposeAsync();
        //}
        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
