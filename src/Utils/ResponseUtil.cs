namespace src.Utils
{
	public class ResponseUtil
    {
		public bool Success { get; set; }
		public object Result { get; set; }

		public ResponseUtil()
		{
		}

		public ResponseUtil(bool success, object result)
		{
			Success = success;
			Result = result;
		}
	}
}