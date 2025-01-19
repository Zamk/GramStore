using CSharpFunctionalExtensions;

namespace GramStore.Nomenclature.Domain.Models
{
    public class Category : Entity
    {
        public const int MAX_NAME_LENGTH = 128;

        public long OrganizationId { get; }
        public string Name { get; } = string.Empty;

        private Category(long id, long organizationId, string name)
        {
            Id = id;
            OrganizationId = organizationId;
            Name = name;
        }

        public static Result<Category> Create(long id, long clientId, string name)
        {
            if (id == 0)
            {
                return Result.Failure<Category>("Id cannot be 0");
            }

            if (clientId == 0)
            {
                return Result.Failure<Category>("Organization id cannot be 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Category>("Name id cannot be null or empty");
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                return Result.Failure<Category>($"Name id cannot be more than {MAX_NAME_LENGTH} length");
            }

            var organization = new Category(id, clientId, name);

            return Result.Success(organization);
        }
    }
}
