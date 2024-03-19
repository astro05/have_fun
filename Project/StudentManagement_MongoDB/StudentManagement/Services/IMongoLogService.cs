using MongoDB.Bson;

namespace StudentManagement.Services
{
    public interface IMongoLogService
    {
        Task<List<string>> GetDatabasesNameAsync();
        Task<List<string>> GetCollectionsNameAsync(string databaseName);
        Task<string> GetDocumentsAsync(string databaseName, string collectionName);
        Task<string> GetDocumentByUniTranIdAsync(string databaseName, string collectionName, string uniTranId);
    }
}
