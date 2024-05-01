using partycli.cli;
using partycli.Services;
using partycli.Services.Registrar;
using Spectre.Console;
using Spectre.Console.Cli;

var services = ServiceRegistry.RegisterServices();
var registrar = new TypeRegistrar(services);

var app = new CommandApp(registrar);

app.Configure(config =>
{
    config.AddCommand<ServerListCommand>("server_list");
    config.AddCommand<ConfigCommand>("config");
});

app.RunAsync(args);
