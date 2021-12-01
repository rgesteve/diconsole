using System;
using System.IO;

using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
#if false
using StreamJsonRpc;

using diconsole.Core;
using diconsole.Server.Services;
#endif

namespace diconsole
{
    class Program
    {
        static /* void */ async Task Main(string[] args)
        {
#if false
	    	Implementation.Server s = new Implementation.Server();
	    	// Console.WriteLine($"An analyzer for language {s.pa.PythonAnalysisSource}.");

		    // Read JSON directly from a file
		    JObject data = JObject.Parse(File.ReadAllText(Path.Combine("..","data.json")));
		    JToken processId = (JToken)data.SelectToken("processId");
	    	JToken capabilities = (JToken)data.SelectToken("capabilities");

		    Console.WriteLine($"testing: {processId}, [{processId.GetType()}]");
		    Console.WriteLine($"testing: {capabilities}, [{capabilities.GetType()}]");
	   		Test(processId);
	    	Test(capabilities);
#else
#if false
			using (CoreShell.Create()) {
				var services = CoreShell.Current.ServiceManager;
				var messageFormatter = new JsonMessageFormatter();
				messageFormatter.JsonSerializer.NullValueHandling   = NullValueHandling.Ignore;
				messageFormatter.JsonSerializer.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
				messageFormatter.JsonSerializer.Converters.Add(new UriConverter());								
			}
#endif
#endif
			IConfigurationRoot config = new ConfigurationBuilder()
						.AddJsonFile("config.json") // the order the providers are added to the builder denotes priority of the config key-values (later takes precedence)
						.AddCommandLine(args)
						.Build();

			Console.WriteLine($"Should be setting backend to {config["preferredBackend"]}");
	    
            Console.WriteLine("Done!");
		    Environment.Exit(0);
        }

#if false
		static void Test(JToken token)
		{
	    	if (token.Type == JTokenType.Object) {
	      		Console.WriteLine("This is an object...");
	    	} else {
    	      Console.WriteLine("Can't tell what this is");
	    	}
		}
#endif
    }

#if false
	sealed class UriConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) => objectType == typeof(Uri);
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.String) {
				var str = (string)reader.Value;
				return new Uri(str.Replace("%3A", ":"));
			}
			if (reader.TokenType == JsonToken.Null) {
				return null;
			}
			throw new InvalidOperationException($"UriConverter: unsupported token type {reader.TokenType}.");
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (null == value) {
				writer.WriteNull();
				return;
			}

			if (value is Uri uri) {
				var scheme = uri.Scheme;
				var str = uri.ToString();
				if (str.Contains("://")) {
					str = uri.Scheme + "://" + str.Substring(scheme.Length + 3).Replace(":", "%3A").Replace('\\', '/');
				}
				writer.WriteValue(str);
				return;
			}
		}
	}
#endif
}
