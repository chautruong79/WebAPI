using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ex5.IRepository;

namespace Ex5.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly RecipeCookwareContext _context;
        private DishTypeRepository _dishTypes;
        private DishRepository _dishes;
        private IngredientRepository _ingredients;
        private RecipeRepository _recipes;

        public UnitOfWork(RecipeCookwareContext context)
        {
            _context = context;
        }
        public IDishTypeRepository DishTypes => _dishTypes = _dishTypes ?? new DishTypeRepository(_context);
        public IDishRepository Dishes => _dishes = _dishes ?? new DishRepository(_context);
        public IIngredientRepository Ingredients => _ingredients = _ingredients ?? new IngredientRepository(_context);
        public IRecipeRepository Recipes => _recipes = _recipes ?? new RecipeRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //public async Task RollbackAsync()
        //{
        //    await _context.DisposeAsync();
        //}
        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
    }
}
