using MongoDB.Bson;

namespace SuperProject.Application.Abstractions
{
    public interface IDataBaseMoveService
    {
        Task<string> GetAllCollectionsAsync();
        Task<bool> CheckCollectionAsync(string nameCollection);
        Task<string> CreateCollectionAsync(string nameCollection);
        Task<string> DropCollectionAsync(string nameCollection);
        Task<string> AddRandomObjectAsync(string nameCollection, BsonDocument obj);
    }
}
