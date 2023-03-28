using System.Net;
using src.Data;
using src.Exceptions;
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

		public async Task<bool> SaveChangesAsync()
		{
			try
			{
				return await _context.SaveChangesAsync() > 0;
			}
			catch (System.Exception ex)
			{
				throw new BaseException($"Erro ao salvar no banco - {ex.Message}", HttpStatusCode.BadRequest, typeof(BadHttpRequestException).FullName, ex.InnerException.Message);
			}
		}
	}
}