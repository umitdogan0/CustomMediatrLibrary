using System.Reflection;
using CustomMediator.Library.Abstractions;
using CustomMediator.Library.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace CustomMediator.Library;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddCustomMediator(this IServiceCollection services, Assembly[] assemblies)
    {
        AssembliesData.AssaAssemblies = assemblies;
        
        return services;
    }
}