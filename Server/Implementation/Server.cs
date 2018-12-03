using System;

using Analyzer;

namespace diconsole.Implementation {
    public class Server
    {
      // If null all files must be added manually
      private string _rootDir;
      internal PythonAnalyzer Analyzer { get; private set; }

      public Server()
      {
      }
    }
}
