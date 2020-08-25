using System;
using System.Collections.Generic;
using System.Text;

namespace Ex5.Entities
{
    public class Recipe
    {
        #region Public Properties
        public int RecipeID { get; set; }
        public int? IngredientID { get; set; }
        public int? DishID { get; set; }
        public int? Quantity { get; set; }
        public string CalculationUnit { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Dish Dish { get; set; }
        #endregion
    }
}
