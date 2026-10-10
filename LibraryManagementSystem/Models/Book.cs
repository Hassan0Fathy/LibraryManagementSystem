using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]

        public string ISBN { get; set; }
        [Required ,Range(1  ,int.MaxValue)]
        public decimal Price { get; set; }
        public Boolean IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }


    }
}
