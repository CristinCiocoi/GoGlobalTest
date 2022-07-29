using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testProjectBackend.DbContext;
using testProjectBackend.DTO;
using testProjectBackend.Models;
using testProjectBackend.Services;

namespace testProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookMarkController : Controller
    {
        private readonly IBookMarkService _bookMarkService;
        private readonly IEmailService _emailService;
        private readonly ApplicationContext _dbContext;

        public BookMarkController(IBookMarkService bookMarkService, IEmailService emailService, ApplicationContext dbContext)
        {
            _bookMarkService = bookMarkService;
            _emailService = emailService;
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookMark>>> GetAll()
        {
            var result = await _bookMarkService.GetAllAsync();
            return result.ToList();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddBookMark([FromBody] BookMarkDto model)
        {
            var entity = new BookMark
            {
                AvatarUrl = model.AvatarUrl,
                Description = model.Description,
                NameRepository = model.NameRepository
            };
            await _bookMarkService.AddBookMarkAsync(entity);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> UnBookMark(Guid id)
        {
            await _bookMarkService.DeleteBookMark(id);
            return Ok();
        }

        [HttpPost("send-msg")]
        public async Task<IActionResult> SendMessageToEmail([FromBody] SendMessageDto email)
        {
            await _emailService.SendEmailAsync("cristintest@outlook.com", email.Email, "Test", "<h1>Hello</h1>");
            return Ok();
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportBookMark()
        {
            var data = await _dbContext.BookMarks.AsQueryable()
                .ToListAsync();

            using var ms = new MemoryStream();
            var configData = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var writeFile = new StreamWriter(ms, leaveOpen: true))
            {
                var csv = new CsvWriter(writeFile, configData);
                csv.WriteRecords(data);
            }

            ms.Position = 0;
            
            return File(ms.ToArray(), "application/octet-stream", "data.csv");
        }
    }
}