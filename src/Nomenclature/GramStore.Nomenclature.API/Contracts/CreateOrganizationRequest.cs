using GramStore.Nomenclature.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GramStore.Nomenclature.API.Contracts
{
    public record CreateOrganizationRequest(
        [Required] long ClientId, 
        [Required][MaxLength(Organization.MAX_NAME_LENGTH)] string Name
        );
}
