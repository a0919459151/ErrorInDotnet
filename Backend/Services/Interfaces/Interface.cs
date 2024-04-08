using Backend.Contracts.Activity;

namespace Backend.Services.Interfaces;

public interface IActivityService
{
    // GetActivities
    Task<GetActivitiesResponseDto> GetActivities(GetActivitiesRequestDto request);

    // GetActivity
    Task<GetActivityResponseDto> GetActivity(int id);
}
