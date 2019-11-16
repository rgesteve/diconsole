using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#if false
using Analyzer;

namespace diconsole.Implementation {
    public class Server
    {

#if false
      /// <summary>
      /// Implements ability to execute module reload on the analyzer thread
      /// </summary>      
      private sealed class ReloadModuleQueueItem : IAnalyzable
      {
          private readonly Server _server;
      }
#endif

      // If null all files must be added manually
      private string _rootDir;
      internal PythonAnalyzer Analyzer { get; private set; }

      public Server()
      {
      }

#if false
      public /* override */ async Task DidChangeConfiguration(/* DidChangeConfigurationParams @params, CancellationToken cancellationToken */)
      {
          // _disposableBag.ThrowIfDisposed();
	  if (Analyzer == null) {
	     //  Change configuration notification sent to uninitialized server
	     return; // shouldn't I be sending an error?
	  }
      }

      public async Task ReloadModulesAsync(CancellationToken token)
      {
#if false
          foreach (var entry in Analyzer.ModulesByFilename) {
	      AnalysisQueue.Enqueue(entry.Value.ProjectEntry, AnalysisPriority.Normal);
	  }
#endif
      }
#endif

      public Task<bool> UnloadFileAsync(Uri documentUri)
      {
	  // uses Analyzer.RemoveModule
          return Task.FromResult(false);
      }

#if false
      public void SetSearchPaths(IEnumerable<string> searchPaths) => Analyzer.SetSearchPaths(searchPaths /* .MaybeEnumerate() */ );
      // ./Analysis/Engine/Impl/Infrastructure/Extensions/EnumerableExtensions.cs:26 -- think this is where MaybeEnumerate is defined

      private async Task DoInitializeAsync(/* InitializeParams @params, CancellationToken ct */)
      {
          // _disposableBag.ThrowIfDisposed();
	  Analyzer = await AnalysisQueue.ExecuteInQueueAsync( ct => CreateAnalyzer(), AnalysisPriority.High );
      }
#endif

#if false
      private T ActivateObject<T>(string assemblyName, string typeName, Dictionary<string, object> properties)
      {
          if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(typeName)) {
	      return default(T);
	  }
      }
#endif

#if false
      private async Task<PythonAnalyzer> CreateAnalyzer(/* PythonInitializationOptions.Interpreter interpreter, CancellationToken token */)
      {
          var factory = ActivateObject<IPythonInterpreterFactory>(interpreter.assembly, interpreter.typeName, interpreter.properties) ?? new AstPythonInterpreterFactory(interpreter.properties);
      }
#endif

    }
}
#endif