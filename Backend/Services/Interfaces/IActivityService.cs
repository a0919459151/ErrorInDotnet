using Backend.Contracts.Activity;

namespace Backend.Services.Interfaces;

public interface IActivityService
{
    // GetActivities
    Task<List<GetActivitiesResponseDto>> GetActivities(GetActivitiesRequestDto request);

    // GetActivitiesPagination
    Task<PaginationList<GetActivitiesPaginationResponseDto>> GetActivitiesPagination(GetActivitiesPaginationRequestDto request);

    // GetActivity
    Task<GetActivityResponseDto> GetActivity(int id);
}
