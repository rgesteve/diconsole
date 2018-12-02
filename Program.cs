﻿using System;
using System.IO;

using Newtonsoft.Json.Linq;

namespace diconsole
{
    class Program
    {
        static void Main(string[] args)
        {
	    Console.WriteLine("Populating databases...");

	    // Read JSON directly from a file
	    JObject data = JObject.Parse(File.ReadAllText(@"data.json"));
	    JToken processId = (JToken)data.SelectToken("processId");
	    JToken capabilities = (JToken)data.SelectToken("capabilities");

	    Console.WriteLine($"testing: {processId}, [{processId.GetType()}]");
	    Console.WriteLine($"testing: {capabilities}, [{capabilities.GetType()}]");
	    Test(processId);
	    Test(capabilities);
	    
            Console.WriteLine("Done!");
	    Environment.Exit(0);
        }

	static void Test(JToken token)
	{
	    if (token.Type == JTokenType.Object) {
	      Console.WriteLine("This is an object...");
	    } else {
    	      Console.WriteLine("Can't tell what this is");
	    }
	}
    }
}
