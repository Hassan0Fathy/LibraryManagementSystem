using LibraryManagementSystem.DTOs.CreateDtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUOW _uow;

        public MemberController(IUOW uow)
        {
            _uow = uow;
        }
        [HttpGet("Top-Readers")]
        public IActionResult TopReader()
        {
            var top = _uow.Member.TopReaders();
            return Ok(top);
        }
        [HttpPost]
        public IActionResult Create(MemberCreateDto dto)
        {
            var member = new Member
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone
            };
            _uow.Member.Add(member);
            _uow.Save();
            return Created();

        }
        [HttpGet("statistics")]
        public IActionResult statistics(int memberId)
        {
            var get = _uow.Member.GetMemberStatics(memberId);
            return Ok(get);
        }


    }
}
