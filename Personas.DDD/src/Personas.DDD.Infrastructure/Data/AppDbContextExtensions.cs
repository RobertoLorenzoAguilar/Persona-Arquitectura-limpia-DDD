using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Personas.DDD.Infrastructure.Data;

public static class AppDbContextExtensions
{
  public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
  {
    services.AddDbContext<AppDbContext>(options =>
         //options.UseSqlite(connectionString));
         //options.UseSqlServer(connectionString));
         options.UseMySQL(connectionString));

  }
}
