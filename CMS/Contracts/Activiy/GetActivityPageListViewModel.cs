namespace CMS.Contracts.Activiy;

public class GetActivityPageListViewModel
{
    public GetActivityPageListQueryModel Query { get; set; } = new GetActivityPageListQueryModel();

    public IPagedList<ActivityPageModel> Activities { get; set; } 
        = new PagedList<ActivityPageModel>(new List<ActivityPageModel>(), PaginationConstants.DefaultPageNumber, PaginationConstants.DefaultPageSize);
}

public class GetActivityPageListQueryModel : IPaginationQuery
{
    public int PageNumber { get; set; } = PaginationConstants.DefaultPageNumber;

    public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;
}

public class ActivityPageModel
{
    public int Id { get; set; }

    public string ActivityName { get; set; } = null!;

    public ActivityType ActivityType { get; set; }
}