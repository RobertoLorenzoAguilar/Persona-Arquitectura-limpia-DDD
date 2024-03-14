using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Personas.DDD.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
