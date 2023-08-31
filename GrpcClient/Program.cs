using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json", true)
    .AddEnvironmentVariables();
var service = builder.Services;
service.AddGrpc();
service.AddSingleton<TestGrpcClient>();
var app = builder.Build();
app.UseRouting();
app.UseHttpsRedirection();
app.Services.GetService<TestGrpcClient>();
app.Run();