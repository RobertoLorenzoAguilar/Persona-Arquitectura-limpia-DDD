using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Personas.DDD.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
