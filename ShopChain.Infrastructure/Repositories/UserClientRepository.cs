using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopChain.Infrastructure.Repositories
{
    public class UserClientRepository : IUserClientRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public UserClientRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _config = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<(bool IsSuccessful, UserClient? User)> Login(string username, string password)
        {
            var user = await _context.UserClients.FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
            if (user != null)
            {
                return (true, user); // Login successful
            }
            return (false, null); // Login failed
        }

        public async Task<string> CreateToken(UserClient user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role ?? "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
