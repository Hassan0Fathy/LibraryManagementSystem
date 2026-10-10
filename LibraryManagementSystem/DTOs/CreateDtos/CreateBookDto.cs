using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.CreateDtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public Boolean IsAvailable { get; set; }
        public int CategoryId { get; set; }
    }
}
