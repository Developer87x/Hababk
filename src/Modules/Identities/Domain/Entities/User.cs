using Hababk.BuildingBlocks.Domain;
using Hababk.Modules.Identities.Domain.DomainEvents;

namespace Hababk.Modules.Identities.Domain.Entities;

public class User:Entity,IAggregateRoot
{
    private User(Guid id,string username,string password,string email) : base(id)
    {
        Username = username ?? throw new NullReferenceException(nameof(username));
        Password = password ?? throw new NullReferenceException(nameof(password));
        Email = email ?? throw new NullReferenceException(nameof(email));
        AddDomainEvent(new CreatedUserDomainEvent(this));
    }
    public string Username { get; private set; } 
    public string Password { get; private set; }
    public string Email { get; private set; }
    
    public static User Create(string username,string password,string email) 
        => new(Guid.NewGuid(),username,password,email);
}  