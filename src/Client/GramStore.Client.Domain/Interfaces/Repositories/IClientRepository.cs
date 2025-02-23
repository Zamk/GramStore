using GramStore.Clients.Domain.Models;

namespace GramStore.Clients.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        public Task Create(Client client);
        public Task GetById(long id);
    }
}
