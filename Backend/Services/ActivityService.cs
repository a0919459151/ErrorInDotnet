using Backend.Contracts.Activity;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class ActivityService : IActivityService
{
    private readonly AppDbContext _context;

    public ActivityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetActivitiesResponseDto> GetActivities(GetActivitiesRequestDto request)
    {
        GetActivitiesResponseDto response = new();

        var activity = await _context.Activities
            .Select(activity => new GetActivitiesResponseDto
            {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                ActivityType = activity.ActivityType,
            })
            .ToListAsync();

        return response;
    }

    public async Task<GetActivitiesPaginationResponseDto> GetActivitiesPagination(GetActivitiesPaginationRequestDto request)
    {
        GetActivitiesPaginationResponseDto response = new();

        var activities = await _context.Activities
            .Select(activity => new ActivitiesPaginationDto
            {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                ActivityType = activity.ActivityType,
            })
            .ToPagedListAsync(request.PageNumber, request.PageSize);

        response.Map(activities);

        return response;
    }

    public async Task<GetActivityResponseDto> GetActivity(int id)
    {
        GetActivityResponseDto response = new();

        var activity = await _context.Activities
            .Select(activity => new GetActivityResponseDto
            {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                ActivityType = activity.ActivityType,
            })
            .FirstOrDefaultAsync(activity => activity.Id == id);

        return response;
    }
}
