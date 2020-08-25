using System;
using System.Collections.Generic;
using System.Text;

namespace Ex5.Entities
{
    public class DishType
    {
        #region Public Properties
        public int DishTypeID { get; set; }
        public string DishTypeName { get; set; }
        public string Description { get; set; }
        public virtual List<Dish> Dishes { get; set; }
        #endregion
    }
}
