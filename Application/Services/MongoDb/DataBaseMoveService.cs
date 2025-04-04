using MongoDB.Bson;
using SuperProject.Application.Abstractions;
using SuperProject.MongoDB.Abstractions;

namespace SuperProject.Application.Services.MongoDb
{
    public class DataBaseMoveService : IDataBaseMoveService
    {
        private readonly IDataBaseMoveRepository _repository;

        public DataBaseMoveService(IDataBaseMoveRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetAllCollectionsAsync()
        {
            return await _repository.GetCollectionsAsync();
        }

        public async Task<bool> CheckCollectionAsync(string nameCollection)
        {
            return await _repository.CheckCollectionAsync(nameCollection);
        }

        public async Task<string> CreateCollectionAsync(string nameCollection)
        {
            return await _repository.CreateCollectionAsync(nameCollection);
        }

        public async Task<string> DropCollectionAsync(string nameCollection)
        {
            return await _repository.DropCollectionAsync(nameCollection);
        }

        public async Task<string> AddRandomObjectAsync(string nameCollection, BsonDocument obj)
        {
            return await _repository.AddRandomObjectAsync(nameCollection, obj);
        }

        public Task<string> RenameCollectionAsync(string oldName, string newName)
        {
            return _repository.RenameCollectionAsync(oldName, newName);
        }

        public Task<string> DeleteRandomObjectOneAsync(string nameCollection, BsonDocument filter)
        {
            return _repository.DeleteRandomObjectOneAsync(nameCollection, filter);
        }

        public Task<string> DeleteRandomObjectManyAsync(string nameCollection, BsonDocument filter)
        {
            return _repository.DeleteRandomObjectManyAsync(nameCollection, filter);
        }

        public Task<string> UpdateRandomObjectOneAsync(string nameCollection, BsonDocument filter, BsonDocument obj)
        {
            return _repository.UpdateRandomObjectOneAsync(nameCollection, filter, obj);
        }

        public Task<string> UpdateRandomObjectManyAsync(string nameCollection, BsonDocument filter, BsonDocument obj)
        {
            return _repository.UpdateRandomObjectManyAsync(nameCollection, filter, obj);
        }
    }
}
