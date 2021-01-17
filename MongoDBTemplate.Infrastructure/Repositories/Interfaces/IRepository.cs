using MongoDBTemplate.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBTemplate.Infrastructure.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(string id);
        Task Add(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(string id);
    }
}
