namespace Hababk.Modules.Stores.Application.Models;

public class StoreDto
{
    public string? StoreName { get; set; }
    public string? Description { get; set; }
    public string? UserId { get; set; }
    public ContactDto? Contact { get; set; }
}

public class ContactDto
{
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
}

