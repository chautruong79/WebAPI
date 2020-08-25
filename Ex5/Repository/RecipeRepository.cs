using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Ex5.IRepository;

namespace Ex5.Repository
{
    class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        private readonly RecipeCookwareContext _context;

        public RecipeRepository(RecipeCookwareContext context) : base(context)
        {
            _context = context;
        }
    }
}
