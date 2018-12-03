using System;
using System.Collections.Generic;

using Analyzer.Parsing;

namespace Analyzer.Interpreter.Ast
{
    public class AstPythonInterpreterFactory : IDisposable
    {
	private readonly bool _useDefaultDatabase;
	private bool _disposed;

	public AstPythonInterpreterFactory()
	{
	}

        public void Dispose()
	{
	}

	public PythonLanguageVersion LanguageVersion { get; }

#if false
	public virtual IPythonInterpreter CreateInterpreter(string workspaceRoot)
	    => new AstPythonInterpreter(this, workspaceRoot, _log);
	public virtual IPythonInterpreter CreateInterpreter()
	    => CreateInterpreter(string.Empty);
#endif
    }
}