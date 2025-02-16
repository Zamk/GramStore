using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GramStore.Nomenclature.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddDbContext<ApplicationContext>();

            return services;
        }
    }
}
