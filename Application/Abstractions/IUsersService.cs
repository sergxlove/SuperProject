using MongoDB.Bson;
using SuperProject.MongoDB.Models;

namespace SuperProject.Application.Abstractions
{
    public interface IUsersService
    {
        Task CreateNewUserAsync(Users user);
        Task<long> DeleteUserAsync(BsonDocument filter);
        Task<List<Users>> ReadUsersAsync(BsonDocument filter);
        Task<long> UpdateUserAsync(BsonDocument filter, Users user);
    }
}
