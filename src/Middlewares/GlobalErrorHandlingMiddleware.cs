using System.Text.Json;
using System.Web;
using src.Exceptions;

namespace src.Middlewares
{
	public class GlobalErrorHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public GlobalErrorHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (System.Exception ex)
			{
				await HandleExceptionAsync(context, (BaseException) ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, BaseException ex)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)ex.StatusCode;
			return context.Response.WriteAsync(JsonSerializer.Serialize(new BaseExceptionReturn(ex.Message, ex.StatusCode, ex.ExceptionType, ex.StackTrace)));
		}
	}
}