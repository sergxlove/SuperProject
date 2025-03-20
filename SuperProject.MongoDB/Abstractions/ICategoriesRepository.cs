using MongoDB.Bson;
using SuperProject.MongoDB.Models;

namespace SuperProject.MongoDB.Abstractions
{
    public interface ICategoriesRepository
    {
        Task CreateAsync(Categories categories);
        Task<long> DeleteAsync(BsonDocument filter);
        Task<List<Categories>> ReadAsync(BsonDocument filter);
        Task<long> UpdateAsync(BsonDocument filter, Categories categories);
    }
}
