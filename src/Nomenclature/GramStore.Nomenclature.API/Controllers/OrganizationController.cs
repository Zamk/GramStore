using GramStore.Nomenclature.API.Contracts;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GramStore.Nomenclature.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(
            IOrganizationService organizationService
            )
        {
            _organizationService = organizationService;
        }
        //[HttpGet]
        //public async Task<ActionResult> GetAllByClientId(long clientId)
        //{
            

        //    return 
        //}


        [HttpPost]
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
