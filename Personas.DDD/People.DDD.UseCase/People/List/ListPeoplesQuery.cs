using Ardalis.Result;
using Ardalis.SharedKernel;
using People.DDD.UseCases.People;

namespace Personas.DDD.UseCases.Contributors.List;

public record ListPeoplesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<PeopleDTO>>>;
