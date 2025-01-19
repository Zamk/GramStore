using CSharpFunctionalExtensions;

namespace GramStore.Nomenclature.Domain.Models
{
    public class Product : Entity
    {
        public const int MAX_NAME_LENGTH = 128;
        public const int MAX_DESCRIPTION_LENGTH = 1024;

        public long OrganizationId { get; }
        public Category Category { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public Image Image { get; }
        public decimal Price { get; }

        private Product(
            long id, 
            long organizationId, 
            Category category, 
            string name, 
            string description, 
            Image image, 
            decimal price)
        {
            Id = id;
            OrganizationId = organizationId;
            Category = category;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }

        public Result<Product> Create(
            long id,
            long organizationId,
            Category category,
            string name,
            string description,
            Image image,
            decimal price) 
        {
            if (id == 0)
            {
                return Result.Failure<Product>("Id cannot be 0");
            }

            if (organizationId == 0)
            {
                return Result.Failure<Product>("Organization id cannot be 0");
            }

            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure<Product>("Name cannot be null or empty");
            }

            if (name.Length > MAX_NAME_LENGTH)
            {
                return Result.Failure<Product>($"Name cannot be more than {MAX_NAME_LENGTH} length");
            }

            if (string.IsNullOrEmpty(description))
            {
                return Result.Failure<Product>("Description cannot be null or empty");
            }

            if (description.Length > MAX_DESCRIPTION_LENGTH)
            {
                return Result.Failure<Product>($"Description cannot be more than {MAX_DESCRIPTION_LENGTH} length");
            }

            if (price < 0)
            {
                return Result.Failure<Product>($"Price cannot be negative");
            }

            var product = new Product(id, organizationId, category, name, description, image, price);

            return Result.Success(product);
        }

    }
}
