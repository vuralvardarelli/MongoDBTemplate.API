using MongoDB.Driver;
using MongoDBTemplate.Core.Models.Entities;
using MongoDBTemplate.Infrastructure.Data;
using MongoDBTemplate.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBTemplate.Infrastructure.Repositories
{
    public class BookRepository : IRepository
    {
        private MongoDBContext _context;

        public BookRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {
            await _context.Books.InsertOneAsync(book);
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Book> filter = Builders<Book>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _context.Books.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Book> GetBook(string id)
        {
            return await _context.Books.Find(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.Find(b => true).ToListAsync();
        }

        public async Task<bool> Update(Book book)
        {
            var updateResult = await _context.Books.ReplaceOneAsync(filter: g => g.Id == book.Id, replacement: book);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
