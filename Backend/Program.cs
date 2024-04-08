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

app.Run();
