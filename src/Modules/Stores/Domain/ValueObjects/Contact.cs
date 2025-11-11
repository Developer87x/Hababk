using Hababk.BuildingBlocks.Domain;

namespace Domain.ValueObjects
{
    public class Contact : ValueObject
    {
        private Contact() { }

        public Contact(string email, string phoneNumber)
        {
            EmailAddress = email;
            PhoneNumber = phoneNumber;
        }

        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {

            yield return new { EmailAddress, PhoneNumber };
        }       
    }
}