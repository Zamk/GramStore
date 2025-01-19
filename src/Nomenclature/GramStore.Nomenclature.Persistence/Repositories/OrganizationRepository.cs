using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Persistence.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly List<Organization> _organizations;

        public OrganizationRepository() 
        { 
            _organizations = new List<Organization>();
        }

        public Task Create(Organization organization)
        {
            _organizations.Add(organization);

            return Task.CompletedTask;
        }

        public Task<List<Organization>> GetByClientId(long clientId)
        {
            var organizations = _organizations.Where(org => org.ClientId == clientId).ToList();

            return Task.FromResult(organizations);
        }

        public Task<Organization> GetById(long id)
        {
            var organization = _organizations.First(org => org.Id == id);

            return Task.FromResult(organization);
        }
    }
}
