using Library.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        LibraryContext context = new LibraryContext();
  
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await context.authors.ToListAsync();
            return Ok(authors);
        }
    }
}
