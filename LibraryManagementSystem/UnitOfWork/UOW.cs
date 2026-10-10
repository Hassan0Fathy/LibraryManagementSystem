using LibraryManagementSystem.AppContext;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repos.ICustomRepo;

namespace LibraryManagementSystem.UnitOfWork
{
    public class UOW : IUOW
    {
        private readonly AppDbContext _context;

        public UOW(AppDbContext context , IBookRepo bookRepo , IUserRepo user , ICategoryRepo category , IMemberRepo member , IBorrowingsRepo borrowings)
        {
            _context = context;
            Book = bookRepo;
            User = user;
            Category = category;
            Member = member;
            Borrowings = borrowings;

        }
        public IBookRepo Book { get; }
        public IUserRepo User { get; }

        public IMemberRepo Member { get; }

        public ICategoryRepo Category { get;}
        public IBorrowingsRepo Borrowings { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
