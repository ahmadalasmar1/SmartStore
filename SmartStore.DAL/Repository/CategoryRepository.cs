using Microsoft.EntityFrameworkCore;
using SmartStore.DAL.Data;
using SmartStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.DAL.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {

            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();

        }

        public async Task AddCategoryAsync(Category category)
        {
             _context.Categories.Add(category);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteCategoryAsync(Category category)
        {
            
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
        }

        

        

        
    }
}
