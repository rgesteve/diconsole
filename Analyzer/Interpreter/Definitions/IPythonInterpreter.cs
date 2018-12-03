using System;
using System.Collections.Generic;

namespace Analyzer.Interpreter
{
    public interface IPythonInterpreter : IDisposable
    {
        void Initialize(PythonAnalyzer state);
	// IPythonType GetBuiltinType(BuiltinTypeId id);
	IList<string> GetModuleNames();
	// event EventHandler ModuleNamesChanged;
	// IPythonModule ImportModule(string name);
	// IModuleContext CreateModuleContext();
    }
}