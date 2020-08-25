using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Entities
{
    public class Task
    {
        #region Public Properties
        public int TaskID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ProjectID { get; set; }
        public int? WorkingHours { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        #endregion
    }
}
