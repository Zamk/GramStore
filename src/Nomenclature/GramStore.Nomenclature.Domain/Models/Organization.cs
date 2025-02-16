using CSharpFunctionalExtensions;

namespace GramStore.Nomenclature.Domain.Models
{
    public class Organization : Entity
    {
        public const int MAX_NAME_LENGTH = 256;

        public long ClientId { get; protected set; }
        public string Name { get; protected set; } = string.Empty;

        protected Organization() { }
        private Organization(long clientId, string name) 
        {
            //Id = id;
            ClientId = clientId;
            Name = name;
        }

        public static Result<Organization> Create(long clientId, string name)
        {
            //if (id == 0)
            //{
            //    return Result.Failure<Organization>("Id cannot be 0");
            //}

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

            var organization = new Organization(clientId, name);

            return Result.Success(organization);
        }
    }
}
