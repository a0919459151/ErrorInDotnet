using Backend.Contracts.Activity;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ActivityController : Controller
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    // Get all activities
    [HttpGet("GetActivities")]
    public async Task<IActionResult> GetActivities([FromQuery] GetActivitiesRequestDto request)
    {
        var response = await _activityService.GetActivities(request);
        return Ok(response);
    }

    // Get all activities pagination
    [HttpGet("GetActivitiesPagination")]
    public async Task<IActionResult> GetActivitiesPagination([FromQuery] GetActivitiesPaginationRequestDto request)
    {
        var response = await _activityService.GetActivitiesPagination(request);
        return Ok(response);
    }

    // Get activity by id
    [HttpGet("GetActivity/{id}")]
    public async Task<IActionResult> GetActivityById(int id)
    {
        var response = await _activityService.GetActivity(id);
        return Ok(response);
    }
}
