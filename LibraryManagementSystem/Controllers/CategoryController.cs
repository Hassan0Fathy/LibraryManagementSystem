using LibraryManagementSystem.DTOs.CreateDtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUOW _uow;
        public CategoryController(IUOW uow)
        {
            _uow = uow;
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };
            _uow.Category.Add(category);
            _uow.Save();
            return Created();

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var getall = _uow.Category.GetByBooks().ToList();
            return Ok(getall);

        }
        [Authorize(Roles ="Admin")]

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var search = _uow.Category.GetById(id);
            _uow.Category.Delete(search);
            _uow.Save();
            return Ok();
        }
    }
}
