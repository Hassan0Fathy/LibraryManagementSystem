using LibraryManagementSystem.DTOs.CreateDtos;
using LibraryManagementSystem.DTOs.ReadDtos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace LibraryManagementSystem.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUOW _uow;
        private readonly IConfiguration _configuration;

        public AuthController(IUOW uow , IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public IActionResult Register(RegisterDto dto)
        {
            var users = _uow.User.GetByName(dto.UserName);
            if(users != null)
            {
                return BadRequest("This User Already Have Account.");
            }
            var newUser = new User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                Role = "Member"
            };
            _uow.User.Add(newUser);
            _uow.Save();
            return Ok();
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            var users = _uow.User.GetByName(dto.UserName);
            if(users == null || users.Password != dto.Password)
            {
                return Unauthorized("Invalid Data.");
            }
            var token = GenerateToken(users);
            return Ok(token);
           


        }
        private string GenerateToken(User user) {

            var key =new SymmetricSecurityKey( Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role ,user.Role)

            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }


    }
}
