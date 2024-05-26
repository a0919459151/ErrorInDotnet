using CMS.Contracts.Activiy;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers;

public class ActivityController : Controller
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    // GetActivityPageList
    public async Task<IActionResult> GetActivityPageList(GetActivityPageListQueryModel query)
    {
        var result = await _activityService.GetActivityPageList(query);

        return View(result.Value);
    }

    // GetActivityList
    public async Task<IActionResult> GetActivityList()
    {
        var result = await _activityService.GetActivityList();

        return View(result.Value);
    }

    // CreateOrUpdateActivity
    public async Task<IActionResult> CreateOrUpdateActivity(int? id)
    {
        CreateOrUpdateActivityViewModel vm;

        // Create
        if (id is null)
        {
            vm = new();

            return View(vm);
        }

        // Update
        var result = await _activityService.GetActivity(id.Value);

        // Fail
        if (result.IsFailure)
        {
            return RedirectToAction(nameof(GetActivityList));
        }
        
        vm = (CreateOrUpdateActivityViewModel)result.Value!;

        return View(vm);
    }

    // CreateOrUpdateActivity post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrUpdateActivity(CreateOrUpdateActivityViewModel vm)
    {
        var result = await _activityService.CreateOrUpdateActivity(vm);

        // Fail
        if (result.IsFailure)
        {
            return View(vm);
        }

        return RedirectToAction(nameof(GetActivityList));
    }

    // DeleteActivity
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteActivity(int id)
    {
        var result = await _activityService.DeleteActivity(id);

        // Fail
        if (result.IsFailure)
        {
            return RedirectToAction(nameof(GetActivityList));
        }

        return RedirectToAction(nameof(GetActivityList));
    }

}
