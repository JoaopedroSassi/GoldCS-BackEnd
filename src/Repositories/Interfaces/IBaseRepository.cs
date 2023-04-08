namespace src.Repositories.Interfaces
{
	public interface IBaseRepository
    {
        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
		int Count<T>() where T : class;
        Task<bool> SaveChangesAsync();
    }
}