using GramStore.Nomenclature.Domain.Exceptions;
using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GramStore.Nomenclature.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        
        public CategoryRepository(
            ApplicationContext context
            ) 
        {
            _context = context;
        }

        public async Task Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public Task<Category> GetById(long id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category is null)
                throw new NotFoundException(typeof(Category), id);

            return Task.FromResult(category);
        }

        public async Task<List<Category>> GetByOrganization(long organizationId)
        {
            return await _context.Categories
                .Where(c => c.OrganizationId == organizationId)
                .ToListAsync();
        }
    }
}
