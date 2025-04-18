using System.Net;
using System.Text.Json;
using src.Exceptions;
using src.Utils;

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
			var statusCode = ex.Data["StatusCode"] ?? HttpStatusCode.BadRequest;
			var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "";
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int) statusCode;
			return context.Response.WriteAsync(JsonSerializer.Serialize(new ResponseUtil(false, new BaseException(ex.Message, (HttpStatusCode)statusCode, innerExceptionMessage))));
		}
	}
}