using Hababk.BuildingBlocks.Domain;

namespace Hababk.Modules.Stores.Domain.ValueObjects
{
    public class Contact(string email, string phoneNumber) : ValueObject
    {
        public string? EmailAddress { get;  } = email;
        public string? PhoneNumber { get;  } = phoneNumber;

        protected override IEnumerable<object> GetEqualityComponents()
        {

            yield return new { EmailAddress, PhoneNumber };
        }       
    }
}