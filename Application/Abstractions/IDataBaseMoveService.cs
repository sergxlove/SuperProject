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
        Task<string> RenameCollectionAsync(string oldName, string newName);
        Task<string> DeleteRandomObjectOneAsync(string nameCollection, BsonDocument filter);
        Task<string> DeleteRandomObjectManyAsync(string nameCollection, BsonDocument filter);
        Task<string> UpdateRandomObjectOneAsync(string nameCollection, BsonDocument filter, BsonDocument obj);
        Task<string> UpdateRandomObjectManyAsync(string nameCollection, BsonDocument filter, BsonDocument obj);

    }
}
