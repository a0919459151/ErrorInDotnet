using Backend.Contracts.ActivityCategories;
using Backend.Services.Interfaces;

namespace Backend.Services;

public class ActivityCategoryService : IActivityCategoryService
{
    public async Task<GetActivityCategoriesResponseDto> GetActivityCategories(GetActivityCategoriesRequestDto request)
    {
        GetActivityCategoriesResponseDto response = new();

        return response;
    }

    public async Task<GetActivityCategoryResponseDto> GetActivityCategory(int id)
    {
        GetActivityCategoryResponseDto response = new();

        return response;
    }
}
