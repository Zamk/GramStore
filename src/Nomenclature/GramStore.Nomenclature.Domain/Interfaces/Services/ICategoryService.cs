using CSharpFunctionalExtensions;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        public Task<Result<Category>> GetCategoryById(long id);
        public Task<Result<List<Category>>> GetCategoriesByOrganizationId(long organizationId);
        public Task<Result<Category>> CreateCategory(long organizationId, string name);
        public Task<Result<Category>> UpdateCategory();
    }
}
