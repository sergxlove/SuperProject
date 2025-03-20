using MongoDB.Bson;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB.Abstractions
{
    public interface IUsersRepository
    {
        Task CreateAsync(Users users);
        Task<long> DeleteAsync(BsonDocument filter);
        Task<List<Users>> ReadAsync(BsonDocument optionsSearch);
        Task<long> UpdateAsync(BsonDocument filter, Users users);
    }
}
