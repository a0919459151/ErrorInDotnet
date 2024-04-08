using Backend.Contracts.ActivityCategories;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ActivityCategoryController : Controller
{
    private readonly IActivityCategoryService _activityCategoryService;

    public ActivityCategoryController(IActivityCategoryService activityCategoryService)
    {
        _activityCategoryService = activityCategoryService;
    }

    // Get all activity categories
    [HttpGet("GetActivityCategories")]
    public async Task<IActionResult> GetActivityCategories([FromQuery] GetActivityCategoriesRequestDto request)
    {
        var response = await _activityCategoryService.GetActivityCategories(request);
        return Ok(response);
    }

    // Get activity category by id
    [HttpGet("GetActivityCategory/{id}")]
    public async Task<IActionResult> GetActivityCategoryById(int id)
    {
        var response = await _activityCategoryService.GetActivityCategory(id);
        return Ok(response);
    }
}
