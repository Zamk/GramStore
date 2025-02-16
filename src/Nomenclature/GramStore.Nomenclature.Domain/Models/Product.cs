using CSharpFunctionalExtensions;

namespace GramStore.Nomenclature.Domain.Models
{
    public class Product : Entity
    {
        public const int MAX_NAME_LENGTH = 128;
        public const int MAX_DESCRIPTION_LENGTH = 1024;

        public Organization Organization { get; protected set; }
        public long OrganizationId { get; protected set; }
        public Category Category { get; protected set; }
        public long CategoryId { get; protected set; }
        public string Name { get; protected set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;
        public Image Image { get; protected set; }
        public decimal Price { get; protected set; }

        private Product() { }

        private Product(
            Organization organization, 
            Category category, 
            string name, 
            string description, 
            Image image, 
            decimal price)
        {
            Organization = organization;
            OrganizationId = organization.Id;
            Category = category;
            CategoryId = category.Id;
            Name = name;
            Description = description;
            Image = image;
            Price = price;
        }

        public static Result<Product> Create(
            Organization organization,
            Category category,
            string name,
            string description,
            Image image,
            decimal price) 
        {
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

            var product = new Product(organization, category, name, description, image, price);

            return Result.Success(product);
        }
    }
}
