using MongoDB.Driver;
using RegistrationMicroservice.Models;

namespace RegistrationMicroservice.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("users");
        }

        public async Task RegisterUser(User user)
        {
           
            var existingUser = await _users.Find(u => u.Email == user.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists");
            }

            await _users.InsertOneAsync(user);
        }
    }
}
