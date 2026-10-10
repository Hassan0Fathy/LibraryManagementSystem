using LibraryManagementSystem.AppContext;
using LibraryManagementSystem.DTOs.ReadDtos;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repos.ICustomRepo;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repos.CustomRepos
{
    public class CategoryRepo : Generic<Category>, ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<CategoryReadDto> GetByBooks()
        {
            return _context.Category.Select(c => new CategoryReadDto
            {
                Name = c.Name,
                CountBook = c.Books.Count()
            }).ToList();
        }
    }
}
