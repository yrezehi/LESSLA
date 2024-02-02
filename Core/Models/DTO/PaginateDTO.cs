namespace Core.Models.DTO
{
    public class PaginateDTO<T> where T : class
    {
        public int Page { get; set; } = 0;
        public int Total { get; set; } = 0;
        public int Pages { get; set; } = 0;
        public IEnumerable<T> Items { get; set; } = new List<T>();
    }
}
