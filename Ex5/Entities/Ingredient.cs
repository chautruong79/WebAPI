using System;
using System.Collections.Generic;

namespace Ex5.Entities
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public string Note { get; set; }
        public virtual List<Recipe> Recipes { get; set; }
    }
}
