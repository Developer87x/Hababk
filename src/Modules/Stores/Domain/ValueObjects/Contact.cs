using Hababk.BuildingBlocks.Domain;

namespace Domain.ValueObjects
{
    public class Contact : ValueObject
    {

        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {

            yield return new { EmailAddress, PhoneNumber };
        }       
    }
}