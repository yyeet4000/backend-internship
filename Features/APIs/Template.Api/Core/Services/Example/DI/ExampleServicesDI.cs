using Template.Api.Core.Services.Example.Contracts;

namespace Template.Api.Core.Services.Example.DI;

public static class ExampleServicesDI
{
    public static IServiceCollection AddExampleServices(
        this IServiceCollection services
    )
    {
        services.AddScoped<ExampleService>();
        services.AddScoped<IExampleService>(
            serviceProvider => serviceProvider.GetRequiredService<ExampleService>()
        );

        return services;
    }
}
