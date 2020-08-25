using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ex4.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IStockTypeRepository StockTypes { get; }
        IStockRepository Stocks { get; }
        IReceiptRepository Receipts { get; }
        IReceiptDetailRepository ReceiptDetails { get; }
        Task<int> CommitAsync();
    }
}
