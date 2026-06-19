using System.Data.Common;

namespace Template.Api.Core.Infrastructure.Persistence;

public interface IAppDbConnectionFactory
{
    Task<DbConnection> OpenAsync(CancellationToken ct = default);
}
