namespace ApplicationCore.Models;

public class PagedResultSet<TEntity> where TEntity: class
{
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int TotalRowCount { get; }
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextpage => PageIndex < TotalPages;
    public IEnumerable<TEntity> Data { get; set; }

    public PagedResultSet(IEnumerable<TEntity> data, int pageIndex, int pageSize, int count)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalRowCount = count;
        Data = data;
        TotalPages = (int) Math.Ceiling(count / (double)pageSize);

    }
}