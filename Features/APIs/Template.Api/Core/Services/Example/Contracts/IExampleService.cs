using Template.Api.Core.Services.Example.DTO;

namespace Template.Api.Core.Services.Example.Contracts;

public interface IExampleService
{
    Task<GetExampleResponse> GetExampleAsync(
        string value,
        CancellationToken ct = default
    );
}
