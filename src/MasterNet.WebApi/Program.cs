using MasterNet.Application;
using MasterNet.Persistence;
using MasterNet.Persistence.Models;
using MasterNet.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);


// builder.Services.AddDbContext<MasterNetDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//     b => b.MigrationsAssembly(typeof(MasterNetDbContext).Assembly.FullName)
//     )
// );


builder.Services.AddControllers();

builder.Services.AddIdentityCore<AppUser>(opt => {
    opt.Password.RequireNonAlphanumeric = false;
    opt.User.RequireUniqueEmail = true;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<MasterNetDbContext>();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

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

