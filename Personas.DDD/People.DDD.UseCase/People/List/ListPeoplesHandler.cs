using Ardalis.Result;
using Ardalis.SharedKernel;
using People.DDD.UseCases.People;
using People.DDD.UseCases.People.List;
using Personas.DDD.UseCases.Contributors.List;

namespace Personas.DDD.UseCases.People;

public class ListPeoplesHandler(IListPeoplesQueryService _query)
  : IQueryHandler<ListPeoplesQuery, Result<IEnumerable<PeopleDTO>>>
{
  public async Task<Result<IEnumerable<PeopleDTO>>> Handle(ListPeoplesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
