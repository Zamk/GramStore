using CSharpFunctionalExtensions;
using GramStore.Clients.Domain.Models;

namespace GramStore.Clients.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<Result<Client>> CreateClient(string name, long telegramId, string? phoneNumber, string? email);
        Task<Result<Client>> GetClientById(long id);
    }
}
