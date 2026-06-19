using Microsoft.EntityFrameworkCore;

namespace Template.Api.Core.Infrastructure.Persistence;

public sealed class AppDbContext(
    DbContextOptions<AppDbContext> options
) : DbContext(options)
{
    // Практиканты добавляют сюда DbSet<TEntity> для своих сущностей.
}
