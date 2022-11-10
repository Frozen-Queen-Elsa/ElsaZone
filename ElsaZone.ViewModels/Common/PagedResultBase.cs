namespace ElsaZone.ViewModels.Common;

public class PagedResultBase<T>
{
    public List<T> Items { set; get; }
    public int TotalRecords { set; get; }
    public int PageSize { set; get; }
    public int PageIndex { set; get; }
    public int PageCount
    {
        get
        {
            var pageCount = (double)TotalRecords / PageSize;
            return (int)Math.Ceiling(pageCount);
        }
    }
}