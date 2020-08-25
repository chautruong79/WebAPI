using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex4.Entities;
using Ex4.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ex4.Repository
{
    class ReceiptRepository : BaseRepository<Receipt>, IReceiptRepository
    {
        private readonly InvoiceMechandisingContext _context;

        public ReceiptRepository(InvoiceMechandisingContext context) : base(context)
        {
            _context = context;
        }
        //public void UndoingChangesDbContextLevel()
        //{
        //    foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry in _context.ChangeTracker.Entries())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Modified:
        //                entry.State = EntityState.Unchanged;
        //                break;
        //            case EntityState.Added:
        //                entry.State = EntityState.Detached;
        //                break;
        //            case EntityState.Deleted:
        //                entry.Reload();
        //                break;
        //            default: break;
        //        }
        //    }
        //}
    }
}
