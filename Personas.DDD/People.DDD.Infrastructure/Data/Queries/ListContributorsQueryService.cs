using People.DDD.UseCases.People;
using People.DDD.UseCases.People.List;
using Microsoft.EntityFrameworkCore;
using People.DDD.UseCases.People;

namespace People.DDD.Infrastructure.Data.Queries;

public class ListContributorsQueryService(AppDbContext _db) : IListContributorsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<PeopleDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Databaseñ.<PeopleDTO>(
      $"SELECT Id, Name, PhoneNumber_Number AS PhoneNumber FROM Contributors") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
