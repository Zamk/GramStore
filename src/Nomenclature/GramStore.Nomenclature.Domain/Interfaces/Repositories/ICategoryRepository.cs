using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public Task Create(Category category);
        public Task<Category> GetById(long id);
        public Task<List<Category>> GetByOrganization(long organizationId);
    }
}
