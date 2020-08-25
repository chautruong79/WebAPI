using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Entities
{
    public class Stock
    {
        #region Public Proerties
        public int StockID { get; set; }
        public int? StockTypeID { get; set; }
        public string StockName { get; set; }
        public double? Price { get; set; }
        public string CalculationUnit { get; set; }
        public int? StockQuantity { get; set; }
        public virtual StockType StockType { get; set; }
        public virtual List<ReceiptDetail> ReceiptDetails { get; set; }
        #endregion
    }
}
