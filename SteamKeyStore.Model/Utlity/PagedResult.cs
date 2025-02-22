namespace SteamKeyStore.Model.Utlity
{
    public class PagedResult<T>
    {
        public List<T> Result { get; set; } = new List<T>();
        public Metadata Metadata { get; set; }

        private PagedResult(List<T> items, int count, int pageNumber, int pageSize)
        {
            this.Metadata = new Metadata(count, pageNumber, pageSize);
            this.Result.AddRange(items);
        }

        public static PagedResult<T> Create(List<T> items, int pageNumber, int pageSize, int totalCount)
        {
            return new PagedResult<T>(items, totalCount, pageNumber, pageSize);
        }
    }
}
