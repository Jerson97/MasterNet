using MasterNet.Application;
using MasterNet.Application.Interface;
using MasterNet.Infrastructure.Photos;
using MasterNet.Infrastructure.Reports;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using MasterNet.WebApi.Extensions;
using MasterNet.WebApi.Middleware;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddPoliciesServices();

builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings)));
builder.Services.AddScoped<IPhotoService, PhotoService>();

//builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped(typeof(IReportService<>), typeof(ReportService<>));

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.UseAuthentication();
app.UseAuthorization();
await app.SeedData();
app.MapControllers();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     try
//     {
//         var context = services.GetRequiredService<MasterNetDbContext>();
//         await context.Database.MigrateAsync();
//     }
//     catch (System.Exception)
//     {
        
//         throw;
//     }
// }


app.Run();

