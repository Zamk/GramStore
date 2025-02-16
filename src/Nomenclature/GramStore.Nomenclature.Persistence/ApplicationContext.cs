using GramStore.Nomenclature.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GramStore.Nomenclature.Persistence
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("OrganizationsDataBase");
        }
    }
}
