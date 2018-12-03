using System;
using System.Collections.Generic;

using Analyzer.Parsing;

namespace Analyzer.Interpreter.Ast
{
    internal class AstPythonInterpreter : /* IPythonInterpreter, */ IModuleContext 
    {

        private readonly string                      _workspaceRoot;
	private readonly AstPythonInterpreterFactory _factory;
	private readonly object                      _userSearchPathsLock = new object();

	private PythonAnalyzer _analyzer;
	// private AstScrapedPythonModule _builtinModule;
	private IReadOnlyList<string> _builtinModuleNames;

	private IReadOnlyList<string> _userSearchPaths;
	private IReadOnlyDictionary<string, string> _userSearchPathPackages;
	private HashSet<string> _userSearchPathImported = new HashSet<string>();

	public AstPythonInterpreter( AstPythonInterpreterFactory factory
	                           , string workspaceRoot
				   /* , AnalysisLogWriter log = null */ )
	{
	    _factory = factory ?? throw new ArgumentNullException(nameof(factory));
	    // _factory.ImportableModulesChanged += Factory_ImportableModulesChanged;
	    _workspaceRoot = workspaceRoot;
	    // Log = log;
	}

	// interface IDisposable
	public void Dispose()
	{
	    // _factory.ImportableModulesChanged -= Factory_ImportableModulesChanged;
	}

	public event EventHandler ModuleNamesChanged;
	public IModuleContext CreateModuleContext() => this;
	// public IPythonInterpreterFactory Factory => _factory;

	// interface IPythonInterpreter
#if false
IPythonInterpreter.Initialize(PythonAnalyzer)

	public IList<string> GetModuleNames()
	{
	}


IPythonInterpreter.ImportModule(string)
IPythonInterpreter.CreateModuleContext()
#endif
    }
}
