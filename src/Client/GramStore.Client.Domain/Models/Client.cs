using CSharpFunctionalExtensions;

namespace GramStore.Clients.Domain.Models
{
    public class Client : Entity
    {
        public string Name { get; protected set; }
        public long TelegramId { get; protected set; }
        public Email? Email { get; protected set; }
        public Phone? Phone { get; protected set; }


        private Client() { }

        public Client(string name, long telegramId, Email? email, Phone? phone) 
        { 
            Name = name;
            TelegramId = telegramId;
            Email = email;
            Phone = phone;
        }

        public static Result<Client> Create(string name, long telegramId, Email? email, Phone? phone)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure<Client>("Name can not be null or white space");
            }

            if (telegramId == 0)
            {
                return Result.Failure<Client>("Name can not be 0");
            }

            var client = new Client(name, telegramId, email, phone);  

            return Result.Success(client);
        }
    }
}
