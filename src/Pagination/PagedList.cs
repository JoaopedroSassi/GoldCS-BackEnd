namespace src.Pagination
{
	public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
		public int TotalPages { get; set; }
		public int PageSize { get; set; }
		public int TotalCount { get; set; }
		public bool hasPrevious => CurrentPage > 1;
		public bool hasNext => CurrentPage < TotalPages;

		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int) Math.Ceiling(count / (double) pageSize);

			AddRange(items);	
		}

		public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
		{
			int count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}