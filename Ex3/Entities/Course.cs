using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ex3.Entities
{
    public class Course
    {
        #region Public Properties
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        [Range(0,10000000)]
        public double? Tuition { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<CourseDate> CourseDates { get; set; }
        #endregion
    }
}
