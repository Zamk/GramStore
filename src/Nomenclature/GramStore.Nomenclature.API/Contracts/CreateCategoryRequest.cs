using GramStore.Nomenclature.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GramStore.Nomenclature.API.Contracts
{
    public record CreateCategoryRequest(
        [Required] long OrganizationId,
        [Required][MaxLength(Category.MAX_NAME_LENGTH)] string Name
        );
}
