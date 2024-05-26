using Backend.Contracts.ActivityCategories;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class ActivityCategoryService : IActivityCategoryService
{
    private readonly AppDbContext _context;

    public ActivityCategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetActivityCategoriesResponseDto>> GetActivityCategories(GetActivityCategoriesRequestDto request)
    {
        var activityCategories = await _context.ActivityCategories
            .Select(activityCategory => new GetActivityCategoriesResponseDto
            {
                Id = activityCategory.Id,
                CategoryName = activityCategory.CategoryName,
            })
            .ToListAsync();

        return activityCategories;
    }

    public async Task<GetActivityCategoryResponseDto> GetActivityCategory(int id)
    {
        var activityCategory = await _context.ActivityCategories
            .Where(activityCategory => activityCategory.Id == id)
            .Select(activityCategory => new GetActivityCategoryResponseDto
            {
                Id = activityCategory.Id,
                CategoryName = activityCategory.CategoryName,
            })
            .FirstOrDefaultAsync();

        if (activityCategory is null)
        {
            throw new AppException(CommonErrorCode.NotFound, "Activity category not found");
        }

        return activityCategory;
    }
}
