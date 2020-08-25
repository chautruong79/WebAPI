using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Entities
{
    public class StockType
    {
        #region Public Properties
        public int StockTypeID { get; set; }
        public string StockTypeName { get; set; }
        public string Description { get; set; }
        public virtual List<Stock> Stocks { get; set; }
        #endregion
    }
}
