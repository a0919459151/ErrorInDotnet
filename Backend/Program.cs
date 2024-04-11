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

    var product = dbContext.Customers.Find(1);

    // Create
    if (product is null)
    {
        var newProduct = new Customer { Name = "Admin", Account = "admin", Password = "123qwe" };

        await dbContext.Customers.AddAsync(newProduct);

        await dbContext.SaveChangesAsync();
    }
}
#endregion