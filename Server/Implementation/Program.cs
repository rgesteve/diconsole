﻿using System;
using System.IO;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;
using StreamJsonRpc;

using diconsole.Core;
using diconsole.Server.Services;

namespace diconsole
{
    class Program
    {
        static void Main(string[] args)
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
			using (CoreShell.Create()) {
				var services = CoreShell.Current.ServiceManager;
				var messageFormatter = new JsonMessageFormatter();
				messageFormatter.JsonSerializer.NullValueHandling   = NullValueHandling.Ignore;
				messageFormatter.JsonSerializer.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
				messageFormatter.JsonSerializer.Converters.Add(new UriConverter());								
			}
#endif
	    
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
}
