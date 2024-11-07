using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Services;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/libraries/{libraryId}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILibrariesService _librariesService;
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService, ILibrariesService librariesService)
        {
            _librariesService = librariesService;
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(int libraryId, [FromQuery] int[] ids)
        {
        var books = await _bookService.Get(libraryId, ids);
        if (books == null || books.Count == 0)
        {
            return NotFound;
        }
        return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooks(Book l)
        {
            await _booksService.Add(l);
            return Ok(l);
        }
    }
}