using Backend.Contracts.ActivityCategories;

namespace Backend.Services.Interfaces;

public interface IActivityCategoryService
{
    // GetActivityCategories
    Task<GetActivityCategoriesResponseDto> GetActivityCategories(GetActivityCategoriesRequestDto request);

    // GetActivityCategory
    Task<GetActivityCategoryResponseDto> GetActivityCategory(int id);
}
