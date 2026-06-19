using Template.Api.Core.Infrastructure.Persistence;
using Template.Api.Core.Services.Example.Contracts;

namespace Template.Api.Core.Services.Example;

/// <summary>
/// Это только пример сервиса для практикантов.
/// Новые сервисы создаются по такой же структуре и содержат запросы конкретной задачи.
/// </summary>
public partial class ExampleService(
    IAppDbConnectionFactory factory
) : IExampleService
{
}
