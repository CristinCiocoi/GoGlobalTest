using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testProjectBackend.DbContext;
using testProjectBackend.Models;

namespace testProjectBackend.Services
{
    public class BookMarkService : IBookMarkService
    {
        private readonly ApplicationContext _dbContext;

        public BookMarkService(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<BookMark>> GetAllAsync()
        {
            return await _dbContext.BookMarks.ToListAsync();
        }

        public async Task AddBookMarkAsync(BookMark entity)
        {
            await _dbContext.BookMarks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookMark(Guid id)
        {
            var bookMark = await _dbContext.BookMarks.AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (bookMark is null)
            {
                throw new Exception("BookMark is not found");
            }
            
           _dbContext.BookMarks.Remove(bookMark);
           _dbContext.SaveChanges();
        }
    }
}