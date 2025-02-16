using CSharpFunctionalExtensions;
using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using GramStore.Nomenclature.Domain.Models;

namespace GramStore.Nomenclature.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(
            IProductRepository productRepository,
            IOrganizationRepository organizationRepository,
            ICategoryRepository categoryRepository
            ) 
        {
            _productRepository = productRepository;
            _organizationRepository = organizationRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<Product>> CreateProduct(
            long organizationId,
            long categoryId, 
            string name,
            string description,
            string imageLink,
            decimal price
            )
        {
            try
            {
                var organization = await _organizationRepository.GetById(organizationId);

                var category = await _categoryRepository.GetById(categoryId);

                var imageResult = Image.Create(imageLink);

                if (imageResult.IsFailure)
                    return Result.Failure<Product>(imageResult.Error);

                var productResult = Product.Create(
                    organization, 
                    category,
                    name, 
                    description,
                    imageResult.Value,
                    price);

                if (productResult.IsFailure)
                    return productResult;

                await _productRepository.Create(productResult.Value);

                return productResult;
            }
            catch (Exception ex )
            {
                return Result.Failure<Product>(ex.Message);
            }
        }

        public async Task<Result<Product>> GetProductById(long id)
        {
            try
            {
                var product = await _productRepository.GetById(id);

                return Result.Success(product);
            }
            catch (Exception ex)
            {
                return Result.Failure<Product>(ex.Message);
            }
        }
        
        public async Task<Result<List<Product>>> GetProductsByOrganizationId(long organizationId)
        {
            try
            {
                _ = await _organizationRepository.GetById(organizationId);

                var products = await _productRepository.GetByOrganization(organizationId);

                return Result.Success(products);
            }
            catch (Exception ex)
            {
                return Result.Failure<List<Product>>(ex.Message);
            }
        }

        public Task<Result<Product>> UpdateProduct()
        {
            throw new NotImplementedException();
        }
    }
}
