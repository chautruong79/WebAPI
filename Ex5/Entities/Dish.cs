using System;
using System.Collections.Generic;
using System.Text;

namespace Ex5.Entities
{
    public class Dish
    {
        #region Public Properties
        public int DishID { get; set; }
        public int? DishTypeID { get; set; }
        public string DishName { get; set; }
        public double? Price { get; set; }
        public string Introduction { get; set; }
        public string Method { get; set; }
        public virtual DishType DishType { get; set; }
        public virtual List<Recipe> Recipes { get; set; }
        #endregion
    }
}
