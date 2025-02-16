using GramStore.Nomenclature.Domain.Exceptions;
using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Persistence.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationContext _context;

        public OrganizationRepository(
            ApplicationContext context
            ) 
        {
            _context = context;
        }

        public async Task Create(Organization organization)
        {
            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();
        }

        public Task<List<Organization>> GetByClientId(long clientId)
        {
            var organizations = _context.Organizations
                .Where(o => o.ClientId == clientId)
                .ToList();

            return Task.FromResult(organizations);
        }

        public Task<Organization> GetById(long id)
        {
            var organization = _context.Organizations.FirstOrDefault(org => org.Id == id);

            if (organization is null)
                throw new NotFoundException(typeof(Organization), id);

            return Task.FromResult(organization);
        }
    }
}
