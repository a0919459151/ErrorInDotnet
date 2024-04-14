using Core.DI;
using CMS.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCookieAuthentication();
builder.Services.AddDbContext();
builder.Services.AddHelpers();
builder.Services.AddServices();
builder.Services.AddHangfire();

var app = builder.Build();

if (app.Environment.IsDevelopment() 
    || app.Environment.IsEnvironment("Local"))
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
