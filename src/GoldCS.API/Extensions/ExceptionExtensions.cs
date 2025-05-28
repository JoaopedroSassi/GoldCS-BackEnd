using System.Net;

namespace src.Extensions
{
	public class ExceptionExtensions 
    {
        public static void ThrowBaseException(string msg, HttpStatusCode statusCode)
		{
			Exception ex = new Exception($"{msg}");
			ex.Data.Add("StatusCode", statusCode);
			throw ex;
		}
    }
}