using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog.Ex.Models;

namespace Serilog.Ex.Services
{
    public class SerilogsServices
    {
        public  IMongoCollection<Serilogs> _CollectionName;

        public SerilogsServices(
            IOptions<MongoDbDatabaseSetting> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                DatabaseSettings.Value.DatabaseName);

            _CollectionName = mongoDatabase.GetCollection<Serilogs>(
                DatabaseSettings.Value.collectionName);

        }

    }
}
