namespace InterfaceSegregation
{
    public interface IRepository<T>
    {
        T Get(int id);
        IList<T> GetAll();
        void Delete(int id);
        void Create(T item);
        void Update(T item);

      
    }
}
