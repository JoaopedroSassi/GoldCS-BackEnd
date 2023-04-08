using System.Net;

namespace src.Exceptions
{
	public class BaseException : Exception
	{
		public new string Message { get; set; }
		public HttpStatusCode StatusCode { get; set; }
		public string InnerExceptionMessage { get; set; }

		public BaseException(string message, HttpStatusCode statusCode, string innerExceptionMessage) : base(message)
		{
			Message = message;
			StatusCode = statusCode;
			InnerExceptionMessage = innerExceptionMessage;
		}

		public BaseException()
		{
		}
	}
}