using iRenta.TestTask.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace iRenta.TestTask.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        // add repositories
        services.Scan(scan => scan
            .FromAssembliesOf(typeof(Repository<>))
            .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }
}
