using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Entities
{
    public class EmployeeTemp
    {
        #region Public Properties
        public int EmployeeTempID { get; set; }
        public int? EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public float? PayRate { get; set; }
        #endregion
        
    }
}
