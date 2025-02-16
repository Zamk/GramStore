using CSharpFunctionalExtensions;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Domain.Interfaces.Services
{
    public interface IProductService
    {
        public Task<Result<Product>> GetProductById(long id);
        public Task<Result<List<Product>>> GetProductByOrganizationId(long organizationId);
        public Task<Result<Product>> CreateProduct(long clientId, string name);
        public Task<Result<Product>> UpdateProduct();
    }
}
