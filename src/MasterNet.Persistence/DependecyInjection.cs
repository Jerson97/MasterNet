using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MasterNet.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MasterNetDbContext>(options => {
        options.LogTo(Console.WriteLine, new [] {
            DbLoggerCategory.Database.Command.Name
        }, LogLevel.Information).EnableSensitiveDataLogging();

        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(MasterNetDbContext).Assembly.FullName));
            
    });

        return services;
    }
}