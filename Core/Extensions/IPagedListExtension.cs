namespace Core.Extensions;

public static class IPagedListExtension
{
    //ToPaginationListAsync
    public static async Task<PaginationList<T>> ToPaginationListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
    {
        var pagedList = await source.ToPagedListAsync(pageNumber, pageSize);
        var paginationList = pagedList.MapToPaginationList();
        return paginationList;
    }

    // MapToPaginationList
    private static PaginationList<T> MapToPaginationList<T>(this IPagedList<T> pagedList)
    {
        var paginationList = new PaginationList<T>()
        {
            Data = pagedList,
            PageCount = pagedList.PageCount,
            TotalItemCount = pagedList.TotalItemCount,
            PageNumber = pagedList.PageNumber,
            PageSize = pagedList.PageSize,
            HasPreviousPage = pagedList.HasPreviousPage,
            HasNextPage = pagedList.HasNextPage,
            IsFirstPage = pagedList.IsFirstPage,
            IsLastPage = pagedList.IsLastPage,
        };

        return paginationList;
    }

}
