﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex4.Entities;

namespace Ex4.IRepository
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        //public void UndoingChangesDbContextLevel();
    }
}
