
using Microsoft.OpenApi.Validations;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.Json;
using System.Xml;

namespace MongoDbLogService.Services
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

        public async Task<bool> DeleteDocumentByUniTranIdAsync(string databaseName, string collectionName, string uniTranId)
        {
            var deleteResult = await _mongoClient.GetDatabase(databaseName)
                                                 .GetCollection<BsonDocument>(collectionName)
                                                 .DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("UniqueTransID", uniTranId));

            return deleteResult.DeletedCount > 0;
        }

        public async Task<bool> UploadDocumentAsync(string databaseName, string collectionName, IFormFile file)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(stream))
                    {
                        var jsonString = await reader.ReadToEndAsync();
                        JObject? jsonObject = JObject.Parse(jsonString);
                        string uniqueTranId = (string)jsonObject["UniqueTransID"];

                     var foundDoc =    GetDocumentByUniTranIdAsync(databaseName, collectionName,uniqueTranId);
                     if (foundDoc.Result is not null)
                            return false;

                        var bsonDocument = BsonDocument.Parse(jsonString);
                            await _mongoClient.GetDatabase(databaseName)
                                                     .GetCollection<BsonDocument>(collectionName)
                                                     .InsertOneAsync(bsonDocument);
                    
                        return true;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
