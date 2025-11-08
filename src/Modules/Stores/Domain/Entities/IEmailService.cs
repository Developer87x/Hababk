namespace Hababk.Modules.Stores.Domain.Entities;

public interface IEmailService
{
   void SendEmail(string email,string subject,string message); 
}