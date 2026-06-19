using Dapper;
using Template.Api.Core.Services.Example.DTO;

namespace Template.Api.Core.Services.Example;

public partial class ExampleService
{
    public async Task<GetExampleResponse> GetExampleAsync(
        string value,
        CancellationToken ct = default
    )
    {
        using var connection = await factory.OpenAsync(ct);

        // Пример параметризованного Dapper-запроса.
        // Практикант заменяет SQL, параметры и DTO в соответствии со своей задачей.
        const string sql = """
            SELECT
                @Value AS "Value",
                CURRENT_TIMESTAMP AT TIME ZONE 'UTC' AS "ServerTimeUtc";
            """;

        return await connection.QuerySingleAsync<GetExampleResponse>(
            new CommandDefinition(
                sql,
                new { Value = value },
                cancellationToken: ct
            )
        );
    }
}
