using CSharpFunctionalExtensions;

namespace GramStore.Client.Domain.Models
{
    public class Email : ValueObject
    {
        public string EmailAddress { get; protected set; } = string.Empty;

        private Email() { }

        private Email(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public static Result<Email> Create(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return Result.Failure<Email>("Email can not be null or white space");
            }

            var email = new Email(emailAddress);

            return Result.Success(email);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EmailAddress;
        }
    }
}
