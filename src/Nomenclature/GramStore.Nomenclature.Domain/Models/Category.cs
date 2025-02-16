using CSharpFunctionalExtensions;

namespace GramStore.Nomenclature.Domain.Models
{
    public class Category : Entity
    {
        public const int MAX_NAME_LENGTH = 128;

        public long OrganizationId { get; protected set; }
        public string Name { get; protected set; } = string.Empty;

        private Category() { }
        private Category(long organizationId, string name)
        {
            OrganizationId = organizationId;
            Name = name;
        }

        public static Result<Category> Create(long organizationId, string name)
        {
            if (organizationId == 0)
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

            var organization = new Category(organizationId, name);

            return Result.Success(organization);
        }
    }
}
