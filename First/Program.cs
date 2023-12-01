using System;
using System.Collections.Generic;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;

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
        services.AddHttpClient();
      })
      .Build().Run();
      Console.WriteLine("Hello, World!");
    }
}
