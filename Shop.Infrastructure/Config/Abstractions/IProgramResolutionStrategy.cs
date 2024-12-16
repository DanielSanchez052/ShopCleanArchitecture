namespace Shop.Infrastructure.Config.Abstractions;

public interface IProgramResolutionStrategy
{
    Task<string> GetProgramIdentifierAsync();
}
