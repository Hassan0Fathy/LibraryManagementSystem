using LibraryManagementSystem.AppContext;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.GenericRepos
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Generic(AppDbContext context) { 

            _context = context;
            _dbSet = _context.Set<T>();


        }

        public void Add(T entity)
        {
           _context.Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

        }

        public ICollection<T> GetAll()
        {
          return  _dbSet.ToList();
        }

        public T GetById(int id)
        {
            var search = _dbSet.Find(id);
            if(search == null)
            {
                throw new Exception("Not Found");
            }   
            return search;
        }

        public void Update(T entity)
        {
           _context.Update(entity);
        }
    }
}
