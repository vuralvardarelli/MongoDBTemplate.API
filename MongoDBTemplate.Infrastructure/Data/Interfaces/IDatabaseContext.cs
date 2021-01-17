using MongoDB.Driver;
using MongoDBTemplate.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBTemplate.Infrastructure.Data.Interfaces
{
    public interface IDatabaseContext
    {
        IMongoCollection<Book> Books { get; }
    }
}
