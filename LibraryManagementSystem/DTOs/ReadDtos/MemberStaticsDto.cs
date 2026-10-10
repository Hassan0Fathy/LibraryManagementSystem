namespace LibraryManagementSystem.DTOs.ReadDtos
{
    public class MemberStaticsDto
    {
        public string MemberName { get; set; }
        public int TotalBorrowedBooks { get; set; }
        public int ReturnedBooks { get; set; }
        public int CurrentlyBorrowedBooks { get; set; }
    }
}
