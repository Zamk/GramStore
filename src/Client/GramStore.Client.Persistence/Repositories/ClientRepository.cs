using GramStore.Clients.Domain.Interfaces.Repositories;
using GramStore.Clients.Domain.Models;

namespace GramStore.Clients.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public ClientRepository(
            
            ) 
        {
        
        }

        public Task Create(Client client)
        {
            throw new NotImplementedException();
        }

        public Task GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
