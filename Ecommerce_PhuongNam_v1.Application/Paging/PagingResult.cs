namespace Ecommerce_PhuongNam_v1.Application.Paging
{
    public class PagingResult<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageTotal { get; set; }
        public List<T> Items { get; set; }
    }
}
