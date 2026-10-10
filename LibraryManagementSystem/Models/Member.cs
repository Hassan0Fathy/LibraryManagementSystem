using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Member
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string FullName {  get; set; }
        [Required , EmailAddress]
        public string Email { get; set; }
        [Required , Phone]
        public string Phone {  get; set; }
        public ICollection<Borrowing > Borrowings { get; set; }



    }
}
