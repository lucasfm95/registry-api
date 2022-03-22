using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RegistryApi.Configuration;
using System.Net.Mime;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesResolveDependencies();
builder.Services.AddRepositoriesResolveDependencies();
builder.Services.AddAuthenticationAuth0Config();
builder.Services.AddControllersConfig();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddHealthCheckConfig();

var app = builder.Build();

app.UseSwaggerConfig();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/HealthCheck",
                new HealthCheckOptions()
                {
                    ResponseWriter = async (context, report) =>
                    {
                        var result = JsonSerializer.Serialize(
                            new
                            {
                                currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                statusApplication = report.Status.ToString(),
                                mongoDbStatus = report.Entries.Values.FirstOrDefault().Status.ToString(),
                            });

                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });

app.Run();
