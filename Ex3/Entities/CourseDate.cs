using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3.Entities
{
    public class CourseDate
    {
        #region Public Properties
        public int CourseDateID { get; set; }
        public int? CourseID { get; set; }
        public string Details { get; set; }
        public string Note { get; set; }
        public virtual Course Course { get; set; }
        #endregion
    }
}
