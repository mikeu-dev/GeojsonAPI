using GeojsonAPI.Models.User;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GeojsonAPI.Repository
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<User>("Users");
        }

        public User GetById(string id) => _users.Find(u => u.Id == id).FirstOrDefault();
        public User GetByUsername(string username) => _users.Find(u => u.Username == username).FirstOrDefault();
        public void Create(User user) => _users.InsertOne(user);
    }
}
