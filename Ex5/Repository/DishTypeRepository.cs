using System;
using System.Collections.Generic;
using System.Text;
using Ex5.Entities;
using Ex5.IRepository;

namespace Ex5.Repository
{
    class DishTypeRepository : BaseRepository<DishType>, IDishTypeRepository
    {
        private readonly RecipeCookwareContext _context;

        public DishTypeRepository(RecipeCookwareContext context) : base(context)
        {
            _context = context;
        }
    }
}
