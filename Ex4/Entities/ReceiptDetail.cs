using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Entities
{
    public class ReceiptDetail
    {
        #region Public Properties
        public int ReceiptDetailID { get; set; }
        public int? StockID { get; set; }
        public int? ReceiptID { get; set; }
        public int? SoldQuantity { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Receipt Receipt { get; set; }
        #endregion
    }
}
