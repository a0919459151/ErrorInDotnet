using CMS.Contracts.Auth;
using CMS.Services.Interfaces;
using Core.EFCore;
using Core.Results;
using Microsoft.EntityFrameworkCore;

namespace CMS.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Login(LoginViewModel model)
    {
        Result result = new();

        var admin = await _context.Admins
            .AsNoTracking()
            .Where(a => a.Account == model.Account)
            .FirstOrDefaultAsync();

        return result.Success();
    }
}
