using MongoDB.Driver;
using tourApiV1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace tourApiV1.Infrastructure.Persistence
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        // Propiedad pública para acceder a _database
        public IMongoDatabase Database => _database;

        public IMongoCollection<Tour> Tours => _database.GetCollection<Tour>("Tours");
    }

}
