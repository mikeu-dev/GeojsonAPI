using GeojsonAPI.Models.User;
using GeojsonAPI.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GeojsonAPI.Service.Auth
{
    public class AuthService
    {
        private readonly UserRepository _userRepo;
        private readonly IConfiguration _config;

        public AuthService(UserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        // ==========================
        // REGISTER
        // ==========================
        public User Register(string username, string email, string password)
        {
            if (_userRepo.GetByUsername(username) != null)
                throw new Exception("Username sudah digunakan");

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password),
                Role = "User"
            };

            _userRepo.Create(user);
            return user;
        }

        // ==========================
        // LOGIN
        // ==========================
        public bool Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);
            if (user == null) return false;
            return VerifyPassword(password, user.PasswordHash);
        }

        // ==========================
        // GENERATE JWT
        // ==========================
        public string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var keyString = jwtSettings["Key"];
            if (string.IsNullOrWhiteSpace(keyString))
                throw new Exception("JWT Key kosong!");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // ==========================
        // HASH & VERIFY PASSWORD
        // ==========================
        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private static bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}
