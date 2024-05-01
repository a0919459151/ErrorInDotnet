using Core.DI;
using Backend.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAllAllowCors();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtAuthentication();
builder.Services.AddDbContext();
builder.Services.AddHelpers();
builder.Services.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment()
    || app.Environment.IsEnvironment("Local"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseErrorHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await DataSeeding();

app.Run();

#region Data seeding
async Task DataSeeding()
{
    using var scope = app.Services.CreateScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();

    var customerAdmin = dbContext.Customers
        .Where(c => c.Name == "CustomerAdmin")
        .FirstOrDefault();

    // Create
    if (customerAdmin is null)
    {
        var password = "123qwe";

        // Get PasswordHasher
        var passwordHasher = scope.ServiceProvider.GetRequiredService<PasswordHasher>();

        // Create a password hash
        var (passwordHash, passwordSalt) = passwordHasher.CreatePasswordHash(password);

        var newAdmin = new Customer { Name = "Admin", Account = "admin", PasswordHash = passwordHash, PasswordSalt = passwordSalt };

        await dbContext.Customers.AddAsync(newAdmin);
        await dbContext.SaveChangesAsync();
    }
}
#endregion