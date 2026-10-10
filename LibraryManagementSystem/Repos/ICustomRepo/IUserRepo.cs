using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace LibraryManagementSystem.Repos.ICustomRepo
{
    public interface IUserRepo : IGeneric<User>
    {
       User GetByName(string username);
    } 
}
