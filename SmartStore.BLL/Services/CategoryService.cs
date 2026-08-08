using SmartStore.DAL.Dto.Request;
using SmartStore.DAL.Dto.Response;
using SmartStore.DAL.Models;
using SmartStore.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository repository)
        {
            _categoryRepository = repository;
            
        }

        public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int id)
        {
            var category =await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null)
            { 
                return null;
            }


             var response = new CategoryResponseDto
              {
                    Id = category.Id,
                    Name = category.Name
              };
                return  response;
            
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync()
        {
            var categories =await _categoryRepository.GetAllCategoriesAsync();

            var response = categories.Select(category => new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name

            });
            return response;
        }

        public async Task<CategoryResponseDto> AddCategoryAsync(CategoryRequestDto request)
        {
            var category = new Category
            {
                Name = request.Name
            };

              await _categoryRepository.AddCategoryAsync(category);

            var respons = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return respons;
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryRequestDto request )
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            { return false; }

            category.Name = request.Name;

            await _categoryRepository.UpdateCategoryAsync(category);
            return true;

            

        }


        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null) {  return false; }
            await _categoryRepository.DeleteCategoryAsync(category);
            return true;
        }

        
    }
}
