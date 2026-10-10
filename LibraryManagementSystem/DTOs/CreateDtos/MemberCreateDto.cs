using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.CreateDtos
{
    public class MemberCreateDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
