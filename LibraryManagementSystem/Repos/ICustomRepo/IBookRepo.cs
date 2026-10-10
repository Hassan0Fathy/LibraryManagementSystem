using LibraryManagementSystem.GenericRepos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repos.ICustomRepo
{
    public interface IBookRepo : IGeneric<Book>
    {
        Book Search(string title, string author);

        Book MostExpensive();

    }
}
