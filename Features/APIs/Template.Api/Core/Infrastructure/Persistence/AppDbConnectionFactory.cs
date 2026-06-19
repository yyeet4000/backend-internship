using System.Data.Common;
using Microsoft.Extensions.Options;
using Npgsql;
using Template.Api.Core.Infrastructure.Persistence.Options;

namespace Template.Api.Core.Infrastructure.Persistence;

public sealed class AppDbConnectionFactory(
    IOptions<AppDbOptions> options
) : IAppDbConnectionFactory
{
    public async Task<DbConnection> OpenAsync(CancellationToken ct = default)
    {
        var connectionString = options.Value.ConnectionString;

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                $"{AppDbOptions.SectionName}:ConnectionString is required."
            );
        }

        var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync(ct);

        return connection;
    }
}
