using GramStore.Nomenclature.Application.Services;
using GramStore.Nomenclature.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GramStore.Nomenclature.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
