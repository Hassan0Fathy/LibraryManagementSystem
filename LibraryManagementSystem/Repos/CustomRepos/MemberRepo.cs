using LibraryManagementSystem.AppContext;
using LibraryManagementSystem.DTOs.ReadDtos;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repos.ICustomRepo;

namespace LibraryManagementSystem.Repos.CustomRepos
{
    public class MemberRepo : Generic<Member>, IMemberRepo
    {
        private readonly AppDbContext _context; 
        public MemberRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<MemberReadDto> TopReaders()
        {
            var top = _context.Member.Select(s => new MemberReadDto
            {
                MemberId = s.Id,
                MemberName = s.FullName,
                BorrowMemberCount = s.Borrowings.Count()

            }).OrderByDescending(s => s.BorrowMemberCount).Take(5).ToList();
            return top;
        }
        public MemberStaticsDto GetMemberStatics(int memberid)
        {
            var get = _context.Member.Where(s => s.Id == memberid).Select(s => new MemberStaticsDto
            {
                MemberName = s.FullName,
                CurrentlyBorrowedBooks = s.Borrowings.Count(b => b.ReturnDate == null),
                TotalBorrowedBooks = s.Borrowings.Count(),
                ReturnedBooks = s.Borrowings.Count(b => b.ReturnDate != null)


            }).FirstOrDefault();
            return get;
        }
    }
}
