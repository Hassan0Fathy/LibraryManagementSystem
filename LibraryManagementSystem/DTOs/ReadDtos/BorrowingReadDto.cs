using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.ReadDtos
{
    public class BorrowingReadDto
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
