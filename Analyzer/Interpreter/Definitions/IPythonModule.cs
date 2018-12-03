using System.Collections.Generic;

namespace Analyzer.Interpreter
{
    public interface IPythonModule : IMember
    {
        string Name { get; }
	IEnumerable<string> GetChildrenModules();
    }
}