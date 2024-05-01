using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;
using ArgumentException = System.ArgumentException;

namespace partycli.Services.Registrar;

public sealed class TypeRegistrar : ITypeRegistrar
{
    private readonly IServiceCollection _builder;
    
    public TypeRegistrar(IServiceCollection builder)
    {
        _builder = builder;
    }
    
    public void Register(Type service, Type implementation)
    {
        _builder.AddSingleton(service, implementation);
    }

    public void RegisterInstance(Type service, object implementation)
    {
        _builder.AddSingleton(service, implementation);
    }

    public void RegisterLazy(Type service, Func<object> factory)
    {
        if (factory is null)
            throw new ArgumentException("Factory func not passed", nameof(factory));
        
        _builder.AddSingleton(service, (provider => factory()));
    }

    public ITypeResolver Build()
    {
        return new TypeResolver(_builder.BuildServiceProvider());
    }
}