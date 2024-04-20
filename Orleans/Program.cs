// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");
//https://learn.microsoft.com/en-us/dotnet/orleans/tutorials-and-samples/tutorial-1

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleans(silo =>
    {
        silo.UseLocalhostClustering()
            .AddMemoryGrainStorage("shopping-cart")
            .AddStartupTask<StartupTask>()
            .ConfigureLogging(logging => logging.AddConsole());
    })
    .UseConsoleLifetime();

using IHost host = builder.Build();

await host.RunAsync();