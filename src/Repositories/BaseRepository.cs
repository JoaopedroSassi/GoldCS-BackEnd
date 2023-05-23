using src.Data;
using src.Repositories.Interfaces;

namespace src.Repositories
{
	public class BaseRepository : IBaseRepository
	{
		private readonly GoldCSDBContext _context;

		public BaseRepository(GoldCSDBContext context)
		{
			_context = context;
		}

		public void Insert<T>(T entity) where T : class
		{
			_context.Add(entity);
		}

		public void Delete<T>(T entity) where T : class
		{
			_context.Remove(entity);
		}

		public void Update<T>(T entity) where T : class
		{
			_context.Update(entity);
		}

		public int Count<T>() where T : class
		{
			return _context.Set<T>().Count();
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() > 0;
		}
	}
}