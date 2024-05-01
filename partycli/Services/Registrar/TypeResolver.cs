using Spectre.Console.Cli;

namespace partycli.Services.Registrar;

public class TypeResolver : ITypeResolver, IDisposable
{
    private IServiceProvider _provider;

    public TypeResolver(IServiceProvider serviceProvider)
    {
        _provider = serviceProvider;
    }
    
    public object? Resolve(Type? type)
    {
        if (type == null)
            return null;
        return _provider.GetService(type);
    }

    public void Dispose()
    {
        if (_provider is IDisposable disposable)
            disposable.Dispose();
    }
}