using GramStore.Nomenclature.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace GramStore.Nomenclature.API.Contracts
{
    public record CreateProductRequest(
        [Required] long OrganizationId,
        [Required] long CategoryId,
        [Required][MaxLength(Product.MAX_NAME_LENGTH)] string Name,
        [Required][MaxLength(Product.MAX_DESCRIPTION_LENGTH)] string Description,
        [Required] string ImageLink,
        [Required] decimal Price
        );
}
