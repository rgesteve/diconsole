using System;
using System.Collections.Generic;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace First;

class Program
{
    static void Main(string[] args)
    {
      Host.CreateDefaultBuilder(args)
      .ConfigureLogging((_, configLogging) => {
        //configLogging.ClearProviders();
      })
      .ConfigureServices(services => {
        // Console.WriteLine("Testing...");
        //services.AddHttpClient();
	//services.AddTelemetryHealthCheckPublisher();
      })
      .Build().Run();
      Console.WriteLine("Hello, World!");
    }
}
