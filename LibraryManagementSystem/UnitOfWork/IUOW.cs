using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repos.ICustomRepo;

namespace LibraryManagementSystem.UnitOfWork
{
    public interface IUOW
    {
        IBookRepo Book { get; }
        IUserRepo User { get; }

        ICategoryRepo Category { get; }
        IMemberRepo Member { get; }

        IBorrowingsRepo Borrowings { get; }
        void Save();
    }
}
