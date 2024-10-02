using Library.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        LibraryContext context = new LibraryContext();
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var categories = await context.categories.ToListAsync();
            return Ok(categories);
        }
    }
}
