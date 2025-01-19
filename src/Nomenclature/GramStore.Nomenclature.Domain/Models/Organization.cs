using CSharpFunctionalExtensions;

namespace GramStore.Nomenclature.Domain.Models
{
    public class Organization
    {
        public const int MAX_NAME_LENGTH = 256;

        public long Id { get; }
        public long ClientId { get; }
        public string Name { get; } = string.Empty;

        private Organization(long id, long clientId, string name) 
        {
            Id = id;
            ClientId = clientId;
            Name = name;
        }

        public static Result<Organization> Create(long id, long clientId, string name)
        {
            if (id == 0)
            {
                return Result.Failure<Organization>("Id cannot be 0");
            }

            if (clientId == 0)
            {
                return Result.Failure<Organization>("Client id cannot be 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Organization>("Name id cannot be null or empty");
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                return Result.Failure<Organization>($"Name id cannot be more than {MAX_NAME_LENGTH} length");
            }

            var organization = new Organization(id, clientId, name);

            return Result.Success(organization);
        }
    }
}
