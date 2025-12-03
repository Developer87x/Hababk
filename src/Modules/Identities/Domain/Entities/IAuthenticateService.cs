using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public interface IAuthenticateService
    {
        Task<bool> ValidateUserCredentials(string username, string password);
        Task<string> GenerateToken(string username);
    }
}