using System.Net;

namespace src.Exceptions
{
	public class BaseExceptionReturn
	{
		public string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public string ExceptionType { get; set; }
		public string StackTrace { get; set; }

		public BaseExceptionReturn(string message, HttpStatusCode statusCode, string exceptionType, string stackTrace)
		{
			Message = message;
			StatusCode = statusCode;
			ExceptionType = exceptionType;
			StackTrace = stackTrace;
		}
	}
}