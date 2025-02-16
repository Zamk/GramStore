using CSharpFunctionalExtensions;
using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
            ICategoryRepository categoryRepository
            ) 
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Category>> CreateCategory(long organizationId, string name)
        {
            var category = Category.Create(organizationId, name);

            if (category.IsFailure)
                return category;

            await _categoryRepository.Create(category.Value);

            return category;
        }

        public async Task<Result<List<Category>>> GetCategoriesByOrganizationId(long organizationId)
        {
            var categories = await _categoryRepository.GetByOrganization(organizationId);

            return categories;
        }

        public async Task<Result<Category>> GetCategoryById(long id)
        {
            try
            {
                var category = await _categoryRepository.GetById(id);
                return Result.Success(category);
            }
            catch (Exception ex)
            {
                return Result.Failure<Category>(ex.Message);
            }
        }

        public Task<Result<Category>> UpdateCategory()
        {
            throw new NotImplementedException();
        }
    }
}
