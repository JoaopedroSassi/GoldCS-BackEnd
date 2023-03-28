using System.Net;

namespace src.Exceptions
{
	public class BaseExceptionReturn
	{
		public string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public string ExceptionType { get; set; }
		public string InnerExceptionMessage { get; set; } = String.Empty;

		public BaseExceptionReturn(string message, HttpStatusCode statusCode, string exceptionType, string innerExceptionMessage)
		{
			Message = message;
			StatusCode = statusCode;
			ExceptionType = exceptionType;
			InnerExceptionMessage = innerExceptionMessage;
		}
	}
}