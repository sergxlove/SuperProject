using MongoDB.Bson;
using SuperProject.Application.Abstractions;
using SuperProject.MongoDB.Abstractions;
using SuperProject.MongoDB.Models;

namespace SuperProject.Application.Services.MongoDb
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task CreateNewUserAsync(Users user)
        {
            await _usersRepository.CreateAsync(user);
        }

        public async Task<List<Users>> ReadUsersAsync(BsonDocument filter)
        {
            return await _usersRepository.ReadAsync(filter);
        }

        public async Task<long> UpdateUserAsync(BsonDocument filter, Users user)
        {
            return await _usersRepository.UpdateAsync(filter, user);
        }

        public async Task<long> DeleteUserAsync(BsonDocument filter)
        {
            return await _usersRepository.DeleteAsync(filter);
        }
    }
}
