using GramStore.Nomenclature.Domain.Interfaces.Repositories;
using GramStore.Nomenclature.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GramStore.Nomenclature.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IOrganizationRepository, OrganizationRepository>();

            return services;
        }
    }
}
