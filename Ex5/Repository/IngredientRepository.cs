using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Ex5.IRepository;

namespace Ex5.Repository
{
    class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        private readonly RecipeCookwareContext _context;

        public IngredientRepository(RecipeCookwareContext context) : base(context)
        {
            _context = context;
        }
    }
}
