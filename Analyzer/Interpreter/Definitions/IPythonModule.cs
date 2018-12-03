using System.Collections.Generic;

namespace Analyzer.Interpreter
{
    public interface IPythonModule : IMember
    {
        string Name { get; }
	IEnumerable<string> GetChildrenModules();
	// void Imported(IModuleContext context);
	string Documentation { get; }
    }
}