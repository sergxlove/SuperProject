namespace SuperProject.Application.Abstractions
{
    public interface IDataBaseMoveService
    {
        Task<string> GetAllCollectionsAsync();
        Task<bool> CheckCollectionAsync(string nameCollection);
        Task<string> CreateCollectionAsync(string nameCollection);
    }
}
