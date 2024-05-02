using Spectre.Console.Cli;

namespace partycli.Services.Registrar;

public class TypeResolver(IServiceProvider serviceProvider) : ITypeResolver, IDisposable
{
    public object? Resolve(Type? type)
    {
        return type == null 
            ? null 
            : serviceProvider.GetService(type);
    }

    public void Dispose()
    {
        if (serviceProvider is IDisposable disposable)
            disposable.Dispose();
    }
}