using SmartStore.DAL.Dto.Request;
using SmartStore.DAL.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.BLL.Services
{
    public interface ICategoryService
    {
        Task <CategoryResponseDto?> GetCategoryByIdAsync(int id);

        Task <IEnumerable<CategoryResponseDto>> GetAllAsync ();

        Task<CategoryResponseDto> AddCategoryAsync(CategoryRequestDto request);

        Task<bool> UpdateCategoryAsync(int id , CategoryRequestDto request);

        Task <bool> DeleteCategoryAsync (int id);
    }
}
