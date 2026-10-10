using LibraryManagementSystem.DTOs.CreateDtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IUOW _uow;


        public BorrowingController(IUOW uow)
        {
            _uow = uow;
        }
        [HttpGet]
        public IActionResult GetAllBorrowings()
        {
            var getall = _uow.Borrowings.OrderNewestBorrwings();
            return Ok(getall);
        }
        [HttpPost]
        public IActionResult Create(CreateBorrowingDto dto)
        {
            var search = _uow.Book.GetById(dto.BookId);
            if(search == null)
            {
                return NotFound(new { message = "Book Not Found." });
            }
            if(search.IsAvailable == false)
            {
                return NotFound(new { message = "Book Is Not Avaliable." }  );
            }
            var search2 = _uow.Member.GetById(dto.MemberId);
            if (search2 == null)
            {
                return NotFound(new { message = "Member Not Found." });
            }
            search.IsAvailable = false;
            _uow.Save();



            var borrow = new Borrowing
            {
                MemberId = dto.MemberId,
                BookId = dto.BookId,
                BorrowDate = DateTime.Now,
                ReturnDate = null
            };
            _uow.Borrowings.Add(borrow);
            _uow.Save();
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateReturn(int id)
        {
            var search = _uow.Borrowings.GetById(id);
            if (search == null)
            {
                return NotFound(new { message = "Borrowing Not Found." });
            }

            if (search.ReturnDate != null)
            {
                return BadRequest(new { message = "This Book Was Returned." });
            }
            var searchBook = _uow.Book.GetById(search.BookId);

            if (searchBook == null)
            {
                return BadRequest(new { message = "This Book Was NotFound." });
            }
            search.ReturnDate = DateTime.Now;
            _uow.Borrowings.Update(search);
            searchBook.IsAvailable = true;
            _uow.Book.Update(searchBook);
            _uow.Save();
            return Ok(); 



        }

    }
}
