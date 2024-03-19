using Ardalis.Result;
using People.DDD.UseCases.People;
using People.DDD.UseCases.People.List;
using FastEndpoints;
using MediatR;
using People.DDD.Web.People;
using Personas.DDD.UseCases.Contributors.List;

namespace Personas.DDD.Web.Peoples;

/// <summary>
/// List all Peoples
/// </summary>
/// <remarks>
/// List all Peoples - returns a PeopleListResponse containing the Peoples.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<PeopleListResponse>
{
  public override void Configure()
  {
    Get("/Peoples");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    Result<IEnumerable<PeopleDTO>> result = await _mediator.Send(new ListPeoplesQuery(null, null), cancellationToken);

    if (result.IsSuccess)
    {
      Response = new PeopleListResponse
      {
        Peoples = result.Value.Select(c => new PeopleRecord(c.Id, c.Name, c.PhoneNumber)).ToList()
      };
    }
  }
}
