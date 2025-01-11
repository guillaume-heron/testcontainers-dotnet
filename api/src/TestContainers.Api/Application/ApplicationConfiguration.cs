namespace TestContainers.Api.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblyContaining<Program>());

        return services;
    }
}