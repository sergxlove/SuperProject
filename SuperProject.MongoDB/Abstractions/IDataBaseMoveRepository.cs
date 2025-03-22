namespace SuperProject.MongoDB.Abstractions
{
    public interface IDataBaseMoveRepository
    {
        Task<string> GetCollectionsAsync();
        Task<bool> CheckCollectionAsync(string nameCollection);
        Task<string> CreateCollectionAsync(string nameCollection);
    }
}
