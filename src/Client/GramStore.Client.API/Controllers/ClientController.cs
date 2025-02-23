using GramStore.Clients.API.Contracts;
using GramStore.Clients.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GramStore.Clients.API.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(
            IClientService clientService
            ) 
        {
            _clientService = clientService;
        }


        [HttpGet]
        [Route("byId/{id}")]
        public async Task<ActionResult> GetId([FromRoute] long id)
        {
            var clientResult = await _clientService.GetClientById(id);

            if (clientResult.IsFailure)
            {
                return BadRequest(clientResult.Error);
            }

            return Ok(clientResult.Value);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromBody] CreateClientRequest request)
        {
            var categoryResult = await _clientService.CreateClient(request.Name, request.TelegramId, request.PhoneNumber, request.Email);

            if (categoryResult.IsFailure)
            {
                return BadRequest(categoryResult.Error);
            }

            return Ok(categoryResult.Value);
        }
    }
}
