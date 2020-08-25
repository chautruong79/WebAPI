using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Entities
{
    public class TaskTemp
    {
        #region Public Properties
        public int TaskTempID { get; set; }
        public int? TaskID { get; set; }
        public int? EmployeeID { get; set; }
        public int? ProjectID { get; set; }
        public int? WorkingHours { get; set; }
        #endregion
    }
}
