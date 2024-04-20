// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Grains.GrainInterfaces;

Console.WriteLine("Hello, World!");


IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .ConfigureLogging(logging => logging.AddConsole())
    .UseConsoleLifetime();

using IHost host = builder.Build();
await host.StartAsync();

IClusterClient client = host.Services.GetRequiredService<IClusterClient>();

IHelloGrain friend = client.GetGrain<IHelloGrain>(0);

string response = await friend.SayHello("Hi friend!");

Console.WriteLine($"response: {response}");

Console.ReadKey();

await host.StopAsync();