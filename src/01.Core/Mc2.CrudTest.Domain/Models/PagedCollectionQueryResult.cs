public class PagedCollectionQueryResult<T>
{
    public int PageNumber { get; }

    public int PageSize { get; }

    public int TotalItems { get; }

    public List<T> Items { get; }

    public PagedCollectionQueryResult(int pageNumber, int pageSize, int totalItems, List<T> items)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalItems = totalItems;
        Items = items;
    }
}