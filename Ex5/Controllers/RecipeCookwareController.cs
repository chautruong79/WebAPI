using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ex5.Entities;
using Ex5.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ex5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeCookwareController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecipeCookwareController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST api/<RecipeCookwareController>/Dish
        [HttpPost]
        [Route("Dish")]
        public async Task<ActionResult<Dish>> CreateDish(Dish dish)
        {
            try
            {
                if (dish == null)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.DishTypes.IsExist(s => s.DishTypeID == dish.DishTypeID))
                {
                    return NotFound("Dish Type Does Not Exist");
                }
                await _unitOfWork.Dishes.Create(dish);
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(CreateDish), new { Id = dish.DishID }, dish);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        private async Task<bool> CreateRecipe(Recipe recipe)
        {
            try
            {
                if (!await _unitOfWork.Ingredients.IsExist(s => s.IngredientID == recipe.IngredientID) || !await _unitOfWork.Dishes.IsExist(s => s.DishID == recipe.DishID))
                {
                    return false;
                }
                Dish dish = await _unitOfWork.Dishes.FindById((int)recipe.DishID);
                Ingredient ingredient = await _unitOfWork.Ingredients.FindById((int)recipe.IngredientID);
                dish.Method = String.Concat(dish.Method, $"\n{ingredient.IngredientName}: {recipe.Quantity} {recipe.CalculationUnit}");
                await _unitOfWork.Recipes.Create(recipe);
                return true;
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }

        // POST api/<RecipeCookwareController>
        [HttpPost("{id}")]
        [Route("Dish/{id}")]
        public async Task<ActionResult> CreateListRecipes(int id, [FromBody] List<Recipe> listRecipes)
        {
            try
            {
                if (id <= 0 || listRecipes.Count == 0 || listRecipes.Any(r => r.DishID != id))
                {
                    return BadRequest();
                }
                Dish d = await _unitOfWork.Dishes.FindById(id) ?? new Dish();
                if (d == null || !await _unitOfWork.Dishes.IsExist(s => s.DishTypeID == d.DishTypeID))
                {
                    return NotFound();
                }
                bool result = true;
                foreach (var r in listRecipes)
                {
                    result = await CreateRecipe(r);
                    if (!result)
                    {
                        break;
                    }
                };
                if (!result)
                {
                    return BadRequest();
                }
                await _unitOfWork.CommitAsync();
                return CreatedAtAction(nameof(CreateListRecipes), new { Id = id }, listRecipes);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        //public async Task<List<Recipe>> EntryListRecipes(int dishID)
        //{
        //    List<Recipe> listRecipes = new List<Recipe>();
        //    do
        //    {
        //        Recipe recipe = new Recipe(InputType.Insert);
        //        if (!await _unitOfWork.Ingredients.IsExist(s => s.IngredientID == recipe.IngredientID))
        //        {
        //            return new List<Recipe>();
        //        }
        //        recipe.DishID = dishID;
        //        listRecipes.Add(recipe);
        //        Console.WriteLine("Do You Want To Add More?(y/N): ");
        //        char answer = Console.ReadKey().KeyChar;
        //        Console.WriteLine();
        //        if (!(char.ToLower(answer) == 'y')) break;
        //    } while (true);
        //    return listRecipes;
        //}

        public async Task<bool> DeleteDishes(int dishTypeID)
        {
            try
            {
                IEnumerable<Dish> listDishes = await _unitOfWork.Dishes.Find(r => r.DishTypeID == dishTypeID);
                foreach (var item in listDishes)
                {
                    IEnumerable<Recipe> listRecipes = await _unitOfWork.Recipes.Find(r => r.DishID == item.DishID);
                    _unitOfWork.Recipes.DeleteRange(listRecipes);
                }
                _unitOfWork.Dishes.DeleteRange(listDishes);
                return true;
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }

        // DELETE api/<RecipeCookwareController>/5
        [HttpDelete("{id}")]
        [Route("DishType/{id}")]
        public async Task<ActionResult> DeleteDishType(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                if (!await _unitOfWork.DishTypes.IsExist(s => s.DishTypeID == id))
                {
                    return NotFound();
                }
                bool result = await DeleteDishes(id);
                if (!result)
                {
                    return BadRequest();
                }
                DishType dishType = await _unitOfWork.DishTypes.FindById(id);
                _unitOfWork.DishTypes.Delete(dishType);
                await _unitOfWork.CommitAsync();
                return Ok(dishType);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }

        // GET: api/<RecipeCookwareController>/Dish
        [HttpGet]
        [Route("Dish")]
        public async Task<ActionResult<List<Dish>>> FindDishes(string name)
        {
            try
            {
                IEnumerable<Dish> listDishes = await _unitOfWork.Dishes.Find(s => s.DishName.ToLower().Contains(name.ToLower()) || s.Method.ToLower().Contains(name.ToLower()));
                if (listDishes.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(listDishes);
            }
            catch (Exception)
            {
                _unitOfWork.Dispose();
                return BadRequest();
            }
        }
    }
}