using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Domain.Interfaces.Repositories
{
    public interface IOrganizationRepository
    {
        public Task Create(Organization organization);
        public Task<Organization> GetById(long id);
        public Task<List<Organization>> GetByClientId(long clientId);
    }
}
