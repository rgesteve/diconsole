using System;
using System.Collections.Generic;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Http;

namespace First;

class Program
{
    static /* void */ async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
        .ConfigureLogging((_, configLogging) =>
        {
            //configLogging.ClearProviders();
        })
        .ConfigureServices(services =>
        {
            services.AddHttpClient();
        })
        .Build();
        
        /* using */ var httpClientFactory = host.Services.GetService<IHttpClientFactory>(); // not sure if this should be a disposable (in which case I could uncomment the `using` stmt)
        if (httpClientFactory == null) {
            Console.WriteLine("Error getting http factory");
        } else {
            var httpClient = httpClientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://google.com");
            using var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfully connected to Google.");
            }
            else
            {
                Console.WriteLine("Failed to connect to Google: " + response.StatusCode);
            }
        }

        // host.Run(); // this goes into an infinite loop that has to be broken out using Ctrl-C
        Console.WriteLine("Hello, World!");
    }
}
