namespace Backend.Contracts.Common;

public class PagedListDto<T>
{
    public IEnumerable<T>? Data { get; set; }

    public int PageCount { get; protected set; }
    public int TotalItemCount { get; protected set; }
    public int PageNumber { get; protected set; }
    public int PageSize { get; protected set; }
    public bool HasPreviousPage { get; protected set; }
    public bool HasNextPage { get; protected set; }
    public bool IsFirstPage { get; protected set; }
    public bool IsLastPage { get; protected set; }
    public int FirstItemOnPage { get; protected set; }
    public int LastItemOnPage { get; protected set; }

    // Map IPagedList
    public void Map(IPagedList<T> pagedList)
    {
        Data = pagedList;
        PageCount = pagedList.PageCount;
        TotalItemCount = pagedList.TotalItemCount;
        PageNumber = pagedList.PageNumber;
        PageSize = pagedList.PageSize;
        HasPreviousPage = pagedList.HasPreviousPage;
        HasNextPage = pagedList.HasNextPage;
        IsFirstPage = pagedList.IsFirstPage;
        IsLastPage = pagedList.IsLastPage;
        FirstItemOnPage = pagedList.FirstItemOnPage;
        LastItemOnPage = pagedList.LastItemOnPage;
    }
}
