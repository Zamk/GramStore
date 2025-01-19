using CSharpFunctionalExtensions;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Domain.Interfaces.Services
{
    public interface IOrganizationService
    {
        public Task<Result<Organization>> GetOrganizationById(long id);
        public Task<Result<Organization>> GetOrganizationByClientId(long clientId);
        public Task<Result<Organization>> CreateOrganization(long clientId, string name);
        public Task<Result<Organization>> UpdateOrganization();
    }
}
