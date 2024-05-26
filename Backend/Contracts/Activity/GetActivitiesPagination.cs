namespace Backend.Contracts.Activity;

public class GetActivitiesPaginationRequestDto : IPaginationQuery
{
    public int PageNumber { get; set; } = PaginationConstants.DefaultPageNumber;

    public int PageSize { get; set; } = PaginationConstants.DefaultPageSize;
}

public class GetActivitiesPaginationResponseDto
{
    public int Id { get; set; }

    public string ActivityName { get; set; } = null!;

    public ActivityType ActivityType { get; set; }
}
