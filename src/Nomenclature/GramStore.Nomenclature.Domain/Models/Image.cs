using CSharpFunctionalExtensions;

namespace GramStore.Nomenclature.Domain.Models
{
    public class Image : ValueObject
    {
        public string Link { get; protected set; } = string.Empty;

        private Image() { }

        private Image(string link) 
        { 
            Link = link;
        }

        public static Result<Image> Create(string link)
        {
            if (string.IsNullOrEmpty(link))
            {
                return Result.Failure<Image>("Link must be not null or empty");
            }

            var image = new Image(link);

            return Result.Success(image);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Link;
        }
    }
}
