using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Ex5.IRepository;

namespace Ex5.Repository
{
    class DishRepository : BaseRepository<Dish>, IDishRepository
    {
        private readonly RecipeCookwareContext _context;

        public DishRepository(RecipeCookwareContext context) : base(context)
        {
            _context = context;
        }
    }
}
