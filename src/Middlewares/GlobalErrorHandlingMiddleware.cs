using System.Net;
using System.Text.Json;
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
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			var statusCode = ex.Data["StatusCode"] != null ? ex.Data["StatusCode"] : HttpStatusCode.BadRequest;
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int) statusCode;
			return context.Response.WriteAsync(JsonSerializer.Serialize(new BaseException(ex.Message, (HttpStatusCode)statusCode)));
		}
	}
}