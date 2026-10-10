using LibraryManagementSystem.AppContext;
using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repos.ICustomRepo;

namespace LibraryManagementSystem.Repos.CustomRepos
{
    public class UserRepo : Generic<User> , IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetByName(string username)
        {
            return _context.Users.FirstOrDefault(s => s.UserName == username);
        }
    }
}
