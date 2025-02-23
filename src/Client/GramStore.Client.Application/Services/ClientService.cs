using CSharpFunctionalExtensions;
using GramStore.Clients.Domain.Interfaces.Repositories;
using GramStore.Clients.Domain.Interfaces.Services;
using GramStore.Clients.Domain.Models;

namespace GramStore.Clients.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(
            IClientRepository repository
            ) 
        {
            _repository = repository;
        }

        public async Task<Result<Client>> CreateClient(string name, long telegramId, string? phoneNumber, string? emailAddress)
        {
            try
            {
                Phone? phone = null;
                Email? email = null;

                if (phoneNumber is not null)
                {
                    var phoneResult = Phone.Create(phoneNumber);

                    if (phoneResult.IsFailure)
                        return Result.Failure<Client>(phoneResult.Error);

                    phone = phoneResult.Value;
                }

                if (emailAddress is not null) 
                {
                    var emailResult = Email.Create(emailAddress);

                    if (emailResult.IsFailure)
                        return Result.Failure<Client>(emailResult.Error);

                    email = emailResult.Value;
                }                

                var clientResult = Client.Create(name, telegramId, email, phone);

                if (clientResult.IsFailure)
                    return clientResult;

                await _repository.Create(clientResult.Value);

                return clientResult;
            }
            catch (Exception ex)
            {
                return Result.Failure<Client>(ex.Message);
            }
        }

        public Task<Result<Client>> GetClientById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
