using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using ArgumentException = System.ArgumentException;

namespace partycli.Services.Registrar;

public sealed class TypeRegistrar(IServiceCollection builder) : ITypeRegistrar
{
    public void Register(Type service, Type implementation)
    {
        builder.AddSingleton(service, implementation);
    }

    public void RegisterInstance(Type service, object implementation)
    {
        builder.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> factory)
    {
        if (factory is null)
            throw new ArgumentException("Factory func not passed", nameof(factory));
        
        builder.AddSingleton(service, (provider => factory()));
    }

    public ITypeResolver Build()
    {
        return new TypeResolver(builder.BuildServiceProvider());
    }
}