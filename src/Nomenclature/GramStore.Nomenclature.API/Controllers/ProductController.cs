using GramStore.Nomenclature.API.Contracts;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GramStore.Nomenclature.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(
            IProductService productService
            ) 
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("byOrganizationId/{organizationId}")]
        public async Task<ActionResult> GetByOrganizationId([FromRoute] long organizationId)
        {
            var productsResult = await _productService.GetProductsByOrganizationId(organizationId);

            if (productsResult.IsFailure)
            {
                return BadRequest(productsResult.Error);
            }

            return Ok(productsResult.Value);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public async Task<ActionResult> GetId([FromRoute] long id)
        {
            var productResult = await _productService.GetProductById(id);

            if (productResult.IsFailure)
            {
                return BadRequest(productResult.Error);
            }

            return Ok(productResult.Value);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var productResult = await _productService.CreateProduct(
                request.OrganizationId,
                request.CategoryId,
                request.Name,
                request.Description,
                request.ImageLink,
                request.Price
                );

            if (productResult.IsFailure)
            {
                return BadRequest(productResult.Error);
            }

            return Ok(productResult.Value);
        }
    }
}
