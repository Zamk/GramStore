﻿using CSharpFunctionalExtensions;

namespace GramStore.Clients.Domain.Models
{
    public class Phone : ValueObject
    {
        public string PhoneNumber { get; protected set; } = string.Empty;

        private Phone() { }
        
        private Phone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public static Result<Phone> Create(string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return Result.Failure<Phone>("Phone can not be null or white space");
            }

            var phone = new Phone(phoneNumber);

            return Result.Success(phone);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PhoneNumber;
        }
    }
}
