using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using testProjectBackend.Models;

namespace testProjectBackend.Services
{
    public interface IBookMarkService
    {
        public Task<IEnumerable<BookMark>> GetAllAsync();
        public Task AddBookMarkAsync(BookMark entity);
        public Task DeleteBookMark(Guid id);
    }
}