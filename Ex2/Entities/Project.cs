using System;
using System.Collections.Generic;
using System.Text;

namespace Ex2.Entities
{
    public class Project
    {
        #region Public Properties
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public virtual List<Task> Tasks { get; set; }
        #endregion
    }
}
