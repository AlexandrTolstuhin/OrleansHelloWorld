using System.Net;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Orleans.Configuration;

await Host.CreateDefaultBuilder(args)
          .UseOrleans(siloBuilder =>
           {
               siloBuilder.UseLocalhostClustering()
                          .AddMemoryGrainStorageAsDefault()
                           // TODO: move to appsettings
                          .Configure<ClusterOptions>(options =>
                           {
                               options.ClusterId = "dev";
                               options.ServiceId = "OrleansHelloWorld";
                           })
                          .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                          .ConfigureLogging(loggingBuilder => loggingBuilder.AddConsole());
           })
          .RunConsoleAsync();