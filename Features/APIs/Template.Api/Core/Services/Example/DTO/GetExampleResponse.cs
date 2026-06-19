namespace Template.Api.Core.Services.Example.DTO;

public sealed class GetExampleResponse
{
    public required string Value { get; init; }

    public DateTime ServerTimeUtc { get; init; }
}
