using GramStore.Nomenclature.API.Contracts;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace GramStore.Nomenclature.API.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            ICategoryService categoryService
            ) 
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("byOrganizationId/{organizationId}")]
        public async Task<ActionResult> GetByOrganizationId([FromRoute] long organizationId)
        {
            var categoriesResult = await _categoryService.GetCategoriesByOrganizationId(organizationId);

            if (categoriesResult.IsFailure)
            {
                return BadRequest(categoriesResult.Error);
            }

            return Ok(categoriesResult.Value);
        }

        [HttpGet]
        [Route("byId/{id}")]
        public async Task<ActionResult> GetId([FromRoute] long id)
        {
            var categoryResult = await _categoryService.GetCategoryById(id);

            if (categoryResult.IsFailure)
            {
                return BadRequest(categoryResult.Error);
            }

            return Ok(categoryResult.Value);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateOrganization([FromBody] CreateCategoryRequest request)
        {
            var categoryResult = await _categoryService.CreateCategory(request.OrganizationId, request.Name);

            if (categoryResult.IsFailure)
            {
                return BadRequest(categoryResult.Error);
            }

            return Ok(categoryResult.Value);
        }
    }
}
