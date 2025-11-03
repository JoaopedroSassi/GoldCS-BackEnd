using GoldCS.Domain.Models.Response;
using System.Text.Json;

namespace GoldCS.API.Middlewares
{
	public class ErrorMiddleware
	{
		private readonly RequestDelegate _requestDelegate;

		public ErrorMiddleware(RequestDelegate requestDelegate)
		{
			_requestDelegate = requestDelegate;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _requestDelegate(context);
			}
			catch (Exception)
			{
				await HandleExceptionAsync(context);
			}
		}

		private static Task HandleExceptionAsync(HttpContext context)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = 500;
			return context.Response.WriteAsync(JsonSerializer.Serialize(new BaseResponse().GenerateCritic(Criticas.ERROINTERNO)));
		}
	}
}