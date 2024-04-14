using Core.DI;
using Core.Helpers;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHangfire();

builder.Services.AddHangfireServer();

builder.Services.Configure<SMTPOption>(builder.Configuration.GetSection(SMTPOption.SMTP));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseHangfireDashboard();

app.Run();

