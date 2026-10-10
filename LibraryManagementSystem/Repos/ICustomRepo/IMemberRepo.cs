using LibraryManagementSystem.DTOs.ReadDtos;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repos.ICustomRepo
{
    public interface IMemberRepo : IGeneric<Member>
    {
        ICollection<MemberReadDto> TopReaders();

        MemberStaticsDto GetMemberStatics(int memberid);
    }
}
