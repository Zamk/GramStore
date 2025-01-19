using CSharpFunctionalExtensions;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        public Task<Result<Organization>> CreateOrganization(
            long clientId,
            string name
            )
        {
            var organization = Organization.Create(
                Random.Shared.NextInt64(), 
                clientId,
                name);

            return Task.FromResult(organization);
        }

        public Task<Result<Organization>> GetOrganizationByClientId(long clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Organization>> GetOrganizationById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Organization>> UpdateOrganization()
        {
            throw new NotImplementedException();
        }
    }
}
