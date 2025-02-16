using CSharpFunctionalExtensions;
using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(
            IOrganizationRepository organizationRepository
            ) 
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<Result<Organization>> CreateOrganization(
            long clientId,
            string name
            )
        {
            var organizationResult = Organization.Create(
                //Random.Shared.NextInt64(), 
                clientId,
                name);

            if (organizationResult.IsFailure)
            {
                return organizationResult;
            }

            await _organizationRepository.Create(organizationResult.Value);

            return organizationResult;
        }

        public async Task<Result<List<Organization>>> GetOrganizationsByClientId(long clientId)
        {
            var organizations = await _organizationRepository.GetByClientId( clientId );

            return Result.Success(organizations);
        }

        public async Task<Result<Organization>> GetOrganizationById(long id)
        {
            try
            {
                var organization = await _organizationRepository.GetById(id);
                return Result.Success(organization);
            }
            catch (Exception ex)
            {
                return Result.Failure<Organization>(ex.Message);
            }
        }

        public Task<Result<Organization>> UpdateOrganization()
        {
            throw new NotImplementedException();
        }
    }
}
