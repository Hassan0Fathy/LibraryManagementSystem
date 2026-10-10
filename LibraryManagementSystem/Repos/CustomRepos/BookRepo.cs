using LibraryManagementSystem.AppContext;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repos.ICustomRepo;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repos.CustomRepos
{
    public class BookRepo : Generic<Book>, IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Book Search(string title, string author)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(author))
            {
                throw new ArgumentException("Title and author cannot both be null or empty.");
            }
            var search = _context.Books
                .Where(b => b.Title.Contains(title) && b.Author.Contains(author))
                .FirstOrDefault();
            return search;

        }
        public Book MostExpensive()
        {
            var mostExpensiveBook = _context.Books
                .OrderByDescending(b => b.Price)
                .FirstOrDefault();
            return mostExpensiveBook;
        }
    }

}
