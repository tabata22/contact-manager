using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Application.Extensions;

public static class MediatrExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        
        return services;
    }
}