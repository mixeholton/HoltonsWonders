using Microsoft.Extensions.DependencyInjection;
using MixeWonders.Values.Context;
using MixeWonders.Values.Services;

namespace MixeWonders.Values.Services;
/// <summary>
/// Helps with using injected dependencies in a scoped context
/// </summary>
public class ScopeService
{
    public interface IProvideDbContext
    {
        BrugsDbContext GetTransactionalDbContext();
    }
    protected IServiceProvider Services { get; }
    public ScopeService(IServiceProvider services)
    {
        Services = services;
    }
    public void ManagedScope(Action<IServiceProvider> action)
    {
        using var scope = Services.CreateScope();
        action(scope.ServiceProvider);
    }
    public T ManagedScope<T>(Func<IServiceProvider, T> action)
    {
        using var scope = Services.CreateScope();
        return action(scope.ServiceProvider);
    }
    public async Task ManagedScopeAsync(Func<IServiceProvider, Task> action)
    {
        using var scope = Services.CreateScope();
        await action(scope.ServiceProvider);
    }
    public async Task<T> ManagedScopeAsync<T>(Func<IServiceProvider, Task<T>> action)
    {
        using var scope = Services.CreateScope();
        return await action(scope.ServiceProvider);
    }
    public async Task PerformTransaction(Func<BrugsDbContext, Task> action)
    {
        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider
            .GetRequiredService<IProvideDbContext>()
            .GetTransactionalDbContext();
        await action(context);
    }
    public async Task<T> PerformTransaction<T>(Func<BrugsDbContext, Task<T>> action)
    {
        using var scope = Services.CreateScope();
        var context = scope.ServiceProvider
            .GetRequiredService<IProvideDbContext>()
            .GetTransactionalDbContext();
        return await action(context);
    }
}
