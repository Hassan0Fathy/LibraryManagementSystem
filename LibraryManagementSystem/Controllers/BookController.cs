using LibraryManagementSystem.DTOs.CreateDtos;
using LibraryManagementSystem.Repos.ICustomRepo;
using LibraryManagementSystem.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IUOW _uow;
        public BookController(IUOW uow)
        {
            _uow = uow;
        }
        [HttpGet("Search")]
        public IActionResult Search(string title, string author)
        {
            var book = _uow.Book.Search(title, author);
            if (book == null)
            {
                return NotFound("Book not found.");
            }
            return Ok(book);
        }
        [HttpGet("MostExpensive")]
        public IActionResult MostExpensive()
        {
            var book = _uow.Book.MostExpensive();
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Create(CreateBookDto dto)
        {
            var book = new Models.Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Price = dto.Price,
                ISBN = dto.ISBN,
                IsAvailable = dto.IsAvailable

            };
            _uow.Book.Add(book);
            _uow.Save();
            return Created();




        }
    }
}
