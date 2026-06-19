namespace Template.Api.Core.Infrastructure.Persistence.Options;

public sealed class AppDbOptions
{
    public static string SectionName => "DB:APP";

    public string? ConnectionString { get; init; }
}
