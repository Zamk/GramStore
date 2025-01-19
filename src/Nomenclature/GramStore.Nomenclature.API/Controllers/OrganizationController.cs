using GramStore.Nomenclature.API.Contracts;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GramStore.Nomenclature.API.Controllers
{
    [ApiController]
    [Route("organization")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(
            IOrganizationService organizationService
            )
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        [Route("byClientId/{clientId}")]
        public async Task<ActionResult> GetByClientId([FromRoute]long clientId)
        {
            var organizationResult = await _organizationService.GetOrganizationsByClientId(clientId);

            if (organizationResult.IsFailure)
            {
                return BadRequest(organizationResult.Error);
            }

            return Ok(organizationResult.Value);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public async Task<ActionResult> GetId([FromRoute] long id)
        {
            var organizationResult = await _organizationService.GetOrganizationById(id);

            if (organizationResult.IsFailure)
            {
                return BadRequest(organizationResult.Error);
            }

            return Ok(organizationResult.Value);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateOrganization([FromBody] CreateOrganizationRequest request)
        {
            var organizationResult = await _organizationService.CreateOrganization(request.ClientId, request.Name);

            if (organizationResult.IsFailure)
            {
                return BadRequest(organizationResult.Error);
            }

            return Ok(organizationResult.Value);
        }
    }
}
