using GeojsonAPI.Models.User;
using GeojsonAPI.Repository;
using System.Security.Cryptography;
using System.Text;

namespace GeojsonAPI.Service.Auth
{
    public class AuthService(UserRepository userRepo)
    {
        private readonly UserRepository _userRepo = userRepo;

        // Register
        public User Register(string username, string email, string password)
        {
            if (_userRepo.GetByUsername(username) != null)
                throw new Exception("Username sudah digunakan");

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = HashPassword(password)
            };

            _userRepo.Create(user);
            return user;
        }

        // Login
        public bool Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);
            if (user == null) return false;

            return VerifyPassword(password, user.PasswordHash);
        }

        // Hash Password
        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        // Verify Password
        private static bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }

        internal object Register(object username, string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
