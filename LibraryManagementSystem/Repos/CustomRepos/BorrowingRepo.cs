using LibraryManagementSystem.AppContext;
using LibraryManagementSystem.DTOs.ReadDtos;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repos.ICustomRepo;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repos.CustomRepos
{
    public class BorrowingRepo : Generic<Borrowing>, IBorrowingsRepo
    {
        private readonly AppDbContext _context;
        public BorrowingRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<BorrowingReadDto> OrderNewestBorrwings()
        {
            return _context.Borrowing.Select(s => new BorrowingReadDto
            {
                Id = s.Id,
                ReturnDate = s.ReturnDate,
                BorrowDate = s.BorrowDate,
                MemberId = s.MemberId,
                Member = s.Member,
                BookId = s.BookId,
                Book = s.Book

            }).OrderByDescending(s=>s.BorrowDate).ToList();
        }
    }
}
