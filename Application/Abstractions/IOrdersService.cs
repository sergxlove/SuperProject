using MongoDB.Bson;
using SuperProject.MongoDB.Models;

namespace SuperProject.Application.Abstractions
{
    public interface IOrdersService
    {
        Task CreateNewOrderAsync(Orders order);
        Task<long> DeleteOrdersAsync(BsonDocument filter);
        Task<List<Orders>> ReadOrdersAsync(BsonDocument filter);
        Task<long> UpdateOrderAsync(BsonDocument filter, Orders order);
    }
}
