using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Entities
{
    public class Student
    {
        #region Public Properties
        public int StudentID { get; set; }
        public int? CourseID { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Course Course { get; set; }
        #endregion
    }
}
