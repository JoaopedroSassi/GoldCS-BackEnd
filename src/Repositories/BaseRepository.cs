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
			try
			{
				_context.Add(entity);
			}
			catch (System.Exception ex)
			{
				string innerExceptionMessage = String.Empty;
				if (!(ex.InnerException is null))
					innerExceptionMessage = ex.InnerException.Message;

				throw new BaseException($"Erro DB - {ex.Message}", HttpStatusCode.BadRequest, typeof(BadHttpRequestException).FullName, ValidateInnerExceptionMessage(ex.InnerException));
			}
		}

		public void Delete<T>(T entity) where T : class
		{
			try
			{
				_context.Remove(entity);
			}
			catch (System.Exception ex)
			{
				string innerExceptionMessage = String.Empty;
				if (!(ex.InnerException is null))
					innerExceptionMessage = ex.InnerException.Message;

				throw new BaseException($"Erro DB - {ex.Message}", HttpStatusCode.BadRequest, typeof(BadHttpRequestException).FullName, ValidateInnerExceptionMessage(ex.InnerException));
			}
		}

		public void Update<T>(T entity) where T : class
		{
			try
			{
				_context.Update(entity);
			}
			catch (System.Exception ex)
			{
				throw new BaseException($"Erro DB - {ex.Message}", HttpStatusCode.BadRequest, typeof(BadHttpRequestException).FullName, ValidateInnerExceptionMessage(ex.InnerException));
			}
		}

		public async Task<bool> SaveChangesAsync()
		{
			try
			{
				return await _context.SaveChangesAsync() > 0;
			}
			catch (System.Exception ex)
			{
				throw new BaseException($"Erro DB - {ex.Message}", HttpStatusCode.BadRequest, typeof(BadHttpRequestException).FullName, ValidateInnerExceptionMessage(ex.InnerException));
			}
		}

		private static string ValidateInnerExceptionMessage(Exception innerException)
		{
			if (!(innerException is null))
				return innerException.Message;
			
			return String.Empty;
		}
	}
}