namespace src.Pagination
{
	public class QueryPaginationParameters
	{
		const int MaxPageSize = 50;
		public int PageNumber { get; set; } = 1;
		public int _pageSize = 10;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}

			set
			{
				_pageSize = (value > MaxPageSize) ? MaxPageSize : value;
			}
		}
	}
}