using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Analyzer.Interpreter
{
    public interface IPythonInterpreter : IDisposable
    {
        void Initialize(PythonAnalyzer state);
	// IPythonType GetBuiltinType(BuiltinTypeId id);
	IList<string> GetModuleNames();
	// event EventHandler ModuleNamesChanged;
	IPythonModule ImportModule(string name);
	IModuleContext CreateModuleContext();
    }

    public interface IPythonInterpreter2 : IPythonInterpreter
    {
	Task<IPythonModule> ImportModuleAsync(string name, CancellationToken token);
    }
}
