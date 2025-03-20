using MongoDB.Bson;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB.Abstractions
{
    public interface IOrdersRepository
    {
        Task CreateAsync(Orders order);
        Task<long> DeleteAsync(BsonDocument filter);
        Task<List<Orders>> ReadAsync(BsonDocument filter);
        Task<long> UpdateAsync(BsonDocument filter, Orders order);
    }
}
