using System;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace First;

class Program
{
    static void Main(string[] args)
    {
      Host.CreateDefaultBuilder(args)
      .ConfigureLogging((_, configLogging) => {
        // configLogging.ClearProviders();
      }).Build().Run();
      Console.WriteLine("Hello, World!");
    }
}
