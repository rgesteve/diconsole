using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

#if false
using diconsole.Core;
#endif

#if false
using Analyzer;
#endif

namespace diconsole.Implementation {
    public class Server : IDisposable
    {
#if false
      private readonly DisposableBag _disposableBag = DisposableBag.Create<Server>();
      private readonly CancellationTokenSource _shutdownCts = new CancellationTokenSource();
      private readonly IServiceManager _services;

      private bool _initialized;

      // If null all files must be added manually
      private string _rootDir;

      public Server(IServiceManager services)
      {
            _services = services;
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

      public Task<bool> UnloadFileAsync(Uri documentUri)
      {
	  // uses Analyzer.RemoveModule
          return Task.FromResult(false);
      }

      public void SetSearchPaths(IEnumerable<string> searchPaths) => Analyzer.SetSearchPaths(searchPaths /* .MaybeEnumerate() */ );
      // ./Analysis/Engine/Impl/Infrastructure/Extensions/EnumerableExtensions.cs:26 -- think this is where MaybeEnumerate is defined

      private async Task DoInitializeAsync(/* InitializeParams @params, CancellationToken ct */)
      {
          // _disposableBag.ThrowIfDisposed();
	  Analyzer = await AnalysisQueue.ExecuteInQueueAsync( ct => CreateAnalyzer(), AnalysisPriority.High );
      }

      private T ActivateObject<T>(string assemblyName, string typeName, Dictionary<string, object> properties)
      {
          if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(typeName)) {
	      return default(T);
	  }
      }

      private async Task<PythonAnalyzer> CreateAnalyzer(/* PythonInitializationOptions.Interpreter interpreter, CancellationToken token */)
      {
          var factory = ActivateObject<IPythonInterpreterFactory>(interpreter.assembly, interpreter.typeName, interpreter.properties) ?? new AstPythonInterpreterFactory(interpreter.properties);
      }
#endif
#endif

#if false
      public void Dispose() => _disposableBag.TryDispose();
#else
      public void Dispose() {
          /* empty */
      }
#endif

    }
}
