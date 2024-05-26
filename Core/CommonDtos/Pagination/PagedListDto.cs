using System.Collections;

namespace Core.CommonDtos.Pagination;

public class PagedListDto<T> : IPagedList<T>
{
    public T this[int index] => throw new NotImplementedException();

    public int PageCount { get; protected set; }
    public int TotalItemCount { get; protected set; }
    public int PageNumber { get; protected set; }
    public int PageSize { get; protected set; }
    public bool HasPreviousPage { get; protected set; }
    public bool HasNextPage { get; protected set; }
    public bool IsFirstPage { get; protected set; }
    public bool IsLastPage { get; protected set; }
    public IEnumerable<T>? Data { get; set; }

    public int FirstItemOnPage => throw new NotImplementedException();

    public int LastItemOnPage => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public PagedListMetaData GetMetaData()
    {
        throw new NotImplementedException();
    }

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
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
