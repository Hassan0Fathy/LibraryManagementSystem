using LibraryManagementSystem.DTOs.ReadDtos;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repos.ICustomRepo
{
    public interface ICategoryRepo : IGeneric<Category>
    {
        ICollection<CategoryReadDto> GetByBooks();
    }
}
