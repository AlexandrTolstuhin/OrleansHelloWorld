using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Orleans.Configuration;

using OrleansHelloWorld.Grains.Abstractions;

var host = new HostBuilder().UseOrleansClient(builder => builder.UseLocalhostClustering()
                                                                 // TODO: move to appsettings
                                                                .Configure<ClusterOptions>(options =>
                                                                 {
                                                                     options.ClusterId = "dev";
                                                                     options.ServiceId = "OrleansHelloWorld";
                                                                 }))
                            .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();
var grain = client.GetGrain<IHelloWorld>("GrainId");

var hello = await grain.SayHelloAsync("User");

Console.WriteLine(hello);

await host.StopAsync();