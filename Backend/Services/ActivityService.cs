using Backend.Contracts.Activity;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class ActivityService : IActivityService
{
    public async Task<GetActivitiesResponseDto> GetActivities(GetActivitiesRequestDto request)
    {
        GetActivitiesResponseDto response = new();

        return response;
    }

    public async Task<GetActivityResponseDto> GetActivity(int id)
    {
        GetActivityResponseDto response = new();

        return response;
    }
}
