using LibraryManagementSystem.DTOs.ReadDtos;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repos.ICustomRepo
{
    public interface IBorrowingsRepo : IGeneric<Borrowing> 
    {
        ICollection<BorrowingReadDto> OrderNewestBorrwings();
    }
}
