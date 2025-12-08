using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Hababk.Modules.Identities.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hababk.Modules.Identities.Infrastructure.Services;
    public class AuthenticateService(IConfiguration configuration, IUserRepository userRepository,IRoleUserRepository roleUserRepository,IRoleRepository roleRepository, IPasswordHash passwordHash) : IAuthenticateService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleUserRepository _roleUserRepository =roleUserRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly IPasswordHash _passwordHash = passwordHash;
        private readonly IConfiguration _configuration = configuration;
        public async Task<string> GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var user = await _userRepository.GetByUserNameAsync(username);
            var userRoles = await _roleUserRepository.GetRolesIdAsync(user?.Id);
            var roles = userRoles.Select(async ur => await _roleRepository.GetByIdAsync(ur.RoleId)).Select(r=>r.Result?.RoleName).ToList();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, user?.Username ?? ""),
                new Claim(ClaimTypes.Sid, user?.Id.ToString() ?? ""),
                new Claim(ClaimTypes.Role, string.Join(",", roles))
            ]),

                Expires = DateTime.UtcNow.AddMinutes(30),
                Audience = _configuration["Jwt:Audience"],
                Issuer = _configuration["Jwt:Issuer"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "")),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> ValidateUserCredentials(string username, string password)
        {
            var user = await _userRepository.GetByUserNameAsync(username) ?? throw new Exception("User not found");
            var isValid = _passwordHash.VerifyPassword(password, user.Password);
            return isValid;
        }
    }