namespace LibraryManagementSystem.GenericRepos
{
    public interface IGeneric<T> where T : class 
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        
        void Update(T entity);  

    }
}
