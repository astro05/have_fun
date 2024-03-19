
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;

namespace StudentManagement.Services
{
    public class MongoLogService : IMongoLogService
    {
        private readonly IMongoClient _mongoClient;
        public MongoLogService(IMongoClient mongoClient) 
        {
           _mongoClient = mongoClient;
        }
        public async Task<List<string>> GetDatabasesNameAsync()
        {
           return (await _mongoClient.ListDatabaseNamesAsync()).ToList();
        }

        public async Task<List<string>> GetCollectionsNameAsync(string databaseName)
        {
            return (await _mongoClient.GetDatabase(databaseName).ListCollectionNamesAsync()).ToList();
        }

        public async Task<string> GetDocumentsAsync(string databaseName, string collectionName)
        {
            var documents = await _mongoClient.GetDatabase(databaseName)
                               .GetCollection<BsonDocument>(collectionName)
                               .Find<BsonDocument>(new BsonDocument())
                               .Project(Builders<BsonDocument>.Projection.Exclude("_id"))
                               .ToListAsync();

            return documents?.ToJson<List<BsonDocument>>(new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson});
        }

        public async Task<string> GetDocumentByUniTranIdAsync(string databaseName, string collectionName, string uniTranId)
        {
            var document = await _mongoClient.GetDatabase(databaseName)
                                             .GetCollection<BsonDocument>(collectionName)
                                             .Find(Builders<BsonDocument>.Filter.Eq("UniqueTransID", uniTranId))
                                             .Project(Builders<BsonDocument>.Projection.Exclude("_id"))
                                             .FirstOrDefaultAsync();

            return document?.ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.RelaxedExtendedJson});
        }

    }
}
