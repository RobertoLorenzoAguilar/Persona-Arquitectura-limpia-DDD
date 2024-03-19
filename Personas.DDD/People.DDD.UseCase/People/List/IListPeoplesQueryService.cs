namespace People.DDD.UseCases.People.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListPeoplesQueryService
{
  Task<IEnumerable<PeopleDTO>> ListAsync();
}
