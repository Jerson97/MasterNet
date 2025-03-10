using FluentValidation;
using FluentValidation.AspNetCore;
using MasterNet.Application.Core;
using MasterNet.Application.Cursos.CursosCreate;
using Microsoft.Extensions.DependencyInjection;

namespace MasterNet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CursosCreateCommand>();

        services.AddAutoMapper(typeof(MappingProfile).Assembly);

        return services;
    }
}