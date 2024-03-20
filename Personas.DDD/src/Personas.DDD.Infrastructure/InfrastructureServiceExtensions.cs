using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Personas.DDD.Core.Interfaces;
using Personas.DDD.Core.Services;
using Personas.DDD.Infrastructure.Data;
using Personas.DDD.Infrastructure.Data.Queries;
using Personas.DDD.Infrastructure.Email;
using Personas.DDD.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Personas.DDD.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config)
    //ILogger logger)
  {
    //string? connectionString = config.GetConnectionString("SqliteConnection");
    //Guard.Against.Null(connectionString);
    //services.AddDbContext<AppDbContext>(options =>
    // options.UseSqlite(connectionString));
    //string? connectionString = config.GetConnectionString("cadenaSql");
    //Guard.Against.Null(connectionString);
    //services.AddDbContext<AppDbContext>(options =>
    // options.UseSqlServer(connectionString));

    #region MYSQL connection
    string? connectionString = config.GetConnectionString("MysqlConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseMySQL(connectionString));
    #endregion MYSQL connection

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IDeleteContributorService, DeleteContributorService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    //logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
