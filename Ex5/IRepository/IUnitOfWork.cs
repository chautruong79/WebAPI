using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ex5.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IDishRepository Dishes { get; }
        IDishTypeRepository DishTypes { get; }
        IIngredientRepository Ingredients { get; }
        IRecipeRepository Recipes { get; }
        Task<int> CommitAsync();
    }
}
