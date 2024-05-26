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

    public async Task<List<GetActivitiesResponseDto>> GetActivities(GetActivitiesRequestDto request)
    {
        var activities = await _context.Activities
            .Select(activity => new GetActivitiesResponseDto
            {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                ActivityType = activity.ActivityType,
            })
            .ToListAsync();

        return activities;
    }

    public async Task<PaginationList<GetActivitiesPaginationResponseDto>> GetActivitiesPagination(GetActivitiesPaginationRequestDto request)
    {
        var activities = await _context.Activities
            .Select(activity => new GetActivitiesPaginationResponseDto
            {
                Id = activity.Id,
                ActivityName = activity.ActivityName,
                ActivityType = activity.ActivityType,
            })
            .ToPaginationListAsync(request.PageNumber, request.PageSize);

        return activities;
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
