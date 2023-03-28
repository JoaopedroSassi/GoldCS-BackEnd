using System.Net;

namespace src.Exceptions
{
	public class BaseException : Exception
	{
		public new string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public string ExceptionType { get; set; }
		public string InnerExceptionMessage { get; set; } = String.Empty;

		public BaseException(string message, HttpStatusCode statusCode, string exceptionType) : base(message)
		{
			Message = message;
			StatusCode = statusCode;
			ExceptionType = exceptionType;
		}

		public BaseException(string message, HttpStatusCode statusCode, string exceptionType, string innerExceptionMessage) : base(message)
		{
			Message = message;
			StatusCode = statusCode;
			ExceptionType = exceptionType;
			InnerExceptionMessage = innerExceptionMessage;
		}

		public BaseException()
		{
		}
	}
}