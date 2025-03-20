using MongoDB.Bson;
using SuperProject.MongoDB.Models;

namespace SuperProject.Application.Abstractions
{
    public interface ICategoriesService
    {
        Task CreateNewCategoryAsync(Categories categories);
        Task<long> DeleteCategoriesAsync(BsonDocument filter);
        Task<List<Categories>> ReadCategoriesAsync(BsonDocument filter);
        Task<long> UpdateCategoriesAsync(BsonDocument filter, Categories categories);
    }
}
