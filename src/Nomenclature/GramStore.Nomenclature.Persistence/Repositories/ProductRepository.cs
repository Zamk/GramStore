using GramStore.Nomenclature.Domain.Exceptions;
using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GramStore.Nomenclature.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(
            ApplicationContext context
            ) 
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public Task<Product> GetById(long id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
                throw new NotFoundException(typeof(Product), id);

            return Task.FromResult(product);
        }

        public async Task<List<Product>> GetByOrganization(long organizationId)
        {
            return await _context.Products
                .Where(p => p.OrganizationId == organizationId)
                .ToListAsync();
        }
    }
}
