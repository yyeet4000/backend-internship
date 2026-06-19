using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Template.Api.Core.Infrastructure.Persistence;
using Template.Api.Core.Infrastructure.Persistence.Options;

namespace Template.Api.Core.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddAppInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services
            .AddOptions<AppDbOptions>()
            .Bind(configuration.GetSection(AppDbOptions.SectionName))
            .Validate(
                options => !string.IsNullOrWhiteSpace(options.ConnectionString),
                $"{AppDbOptions.SectionName}:ConnectionString is required."
            )
            .ValidateOnStart();

        // Dapper использует эту фабрику подключения.
        services.AddScoped<IAppDbConnectionFactory, AppDbConnectionFactory>();

        // EF Core использует ту же строку подключения.
        services.AddDbContext<AppDbContext>((serviceProvider, options) =>
        {
            var dbOptions = serviceProvider
                .GetRequiredService<IOptions<AppDbOptions>>()
                .Value;

            options.UseNpgsql(dbOptions.ConnectionString);
        });

        return services;
    }
}
