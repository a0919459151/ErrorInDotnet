using Backend.Contracts.Common;

namespace Backend.Contracts.Activity;

public class GetActivitiesPaginationRequestDto : IPaginationQuery
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }
}

public class GetActivitiesPaginationResponseDto : PagedListDto<ActivitiesPaginationDto>
{
}

public class ActivitiesPaginationDto
{
    public int Id { get; set; }

    public string ActivityName { get; set; } = null!;

    public ActivityType ActivityType { get; set; }
}
