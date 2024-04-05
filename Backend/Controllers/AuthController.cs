using Backend.Contracts.Auth;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Login
    [HttpPost]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        return Ok();
    }
}
