using MongoDB.Driver;
using MongoDBTemplate.Core.Models.Common;
using MongoDBTemplate.Core.Models.Entities;
using MongoDBTemplate.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBTemplate.Infrastructure.Data
{
    public class MongoDBContext : IDatabaseContext
    {
        private AppSettings _settings;

        public MongoDBContext(AppSettings settings)
        {
            _settings = settings;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            //database.CreateCollection(settings.CollectionName);

            Books = database.GetCollection<Book>(settings.CollectionName);
        }

        public IMongoCollection<Book> Books { get; }
    }
}
