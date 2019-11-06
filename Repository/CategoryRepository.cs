using System.Collections.Generic;
using AspNetCoreBookStore.Data;
using AspNetCoreBookStore.Interfaces;
using AspNetCoreBookStore.Models;

namespace AspNetCoreBookStore.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> AllCategorys => _context.Categories;
    }
}