namespace Core.CommonDtos.Pagination;

public interface IPaginationQuery
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}
