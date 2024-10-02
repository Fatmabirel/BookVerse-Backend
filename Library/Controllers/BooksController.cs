using Library.Context;
using Library.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        LibraryContext context = new LibraryContext();

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var books = await context.books
                 .Include(b => b.Author) 
                 .Include(b => b.Category) 
                 .ToListAsync();

            var bookDtos = books.Select(b => new BookDto
            {
                Id = b.id,
                Title = b.title,
                PublicationYear = b.publication_year,
                Stock = b.stock,
                ImageUrl = b.image_url,
                AuthorName = b.Author.name,
                CategoryName = b.Category.name
            }).ToList();

            return Ok(bookDtos);
        }
    }
}
