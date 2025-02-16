using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task Create(Product product);
        public Task<Product> GetById(long id);
        public Task<List<Product>> GetByOrganization(long organizationId);
    }
}
