namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IBaseCrudRepository<T> where T : class
    {
        Task Insert(T entity); 
        Task Update(T entity);
        Task Delete(T entity);
    }
}
