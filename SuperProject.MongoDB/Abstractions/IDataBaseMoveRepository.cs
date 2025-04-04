using MongoDB.Bson;

namespace SuperProject.MongoDB.Abstractions
{
    public interface IDataBaseMoveRepository
    {
        Task<string> GetCollectionsAsync();
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
