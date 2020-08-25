using System;
using System.Collections.Generic;
using System.Text;

namespace Ex4.Entities
{
    public class Receipt
    {
        #region Public Properties
        public int ReceiptID { get; set; }
        public DateTime? DateCreated { get; set; }
        public string StaffCreated { get; set; }
        public string Note { get; set; }
        public double? TotalAmount { get; set; }
        public virtual List<ReceiptDetail> ReceiptDetails { get; set; }
        #endregion
    }
}
