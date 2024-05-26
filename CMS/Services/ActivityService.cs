using CMS.Contracts.Activiy;
using X.PagedList;

namespace CMS.Services;

public class ActivityService : IActivityService
{
    private readonly AppDbContext _context;

    public ActivityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> GetActivityPageList(GetActivityPageListQueryModel query)
    {
        GetActivityPageListViewModel vm;

        // Query
        var activities = await _context.Activities
            .AsNoTracking()
            .Select(a => new ActivityPageModel
            {
                Id = a.Id,
                ActivityName = a.ActivityName,
                ActivityType = a.ActivityType
            })
            .ToPagedListAsync(query.PageNumber, query.PageSize);

        // Mapping
        vm = new GetActivityPageListViewModel()
        {
            Activities = activities
        };

        return Result.Success(vm);
    }

    public async Task<Result> GetActivityList()
    {
        GetActivityListViewModel vm;

        // Query
        var activities = await _context.Activities
            .AsNoTracking()
            .ToListAsync();

        // Mapping
        vm = new GetActivityListViewModel()
        {
            Activities = activities
                .Select(a => new ActivityModel
                {
                    Id = a.Id,
                    ActivityName = a.ActivityName,
                    ActivityType = a.ActivityType
                })
                .ToList()
        };

        return Result.Success(vm);
    }

    public async Task<Result> GetActivity(int id)
    {
        CreateOrUpdateActivityViewModel vm;

        // Query
        var activity = await _context.Activities
            .AsNoTracking()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        // Not found
        if (activity is null)
        {
            return Result.NotFound("Activity not found");
        }

        // Mapping
        vm = new CreateOrUpdateActivityViewModel
        {
            Id = activity.Id,
            ActivityName = activity.ActivityName,
            ActivityType = activity.ActivityType
        };

        return Result.Success(vm);
    }

    public async Task<Result> CreateOrUpdateActivity(CreateOrUpdateActivityViewModel vm)
    {
        // TODO:
        // Validate model
        // if validate fail, return

        // Create
        if (vm.Id is null)
        {
            var activity = new Activity
            {
                ActivityName = vm.ActivityName,
                ActivityType = vm.ActivityType
            };

            await _context.Activities.AddAsync(activity);

            await _context.SaveChangesAsync();

            return Result.Success();
        }
        // Update
        else
        {
            // Query
            var activity = _context.Activities
                .Where(a => a.Id == vm.Id)
                .FirstOrDefault();

            // Not found
            if (activity is null)
            {
                return Result.NotFound("Activity not found");
            }

            activity.ActivityName = vm.ActivityName;
            activity.ActivityType = vm.ActivityType;

            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }

    public async Task<Result> DeleteActivity(int id)
    {
        // Query
        var activity = _context.Activities
            .Where(a => a.Id == id)
            .FirstOrDefault();

        // Not found
        if (activity is null)
        {
            return Result.NotFound("Activity not found");
        }

        // Delete
        _context.Activities.Remove(activity);

        await _context.SaveChangesAsync();

        return Result.Success();
    }

   
}
