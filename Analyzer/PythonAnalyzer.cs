using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Analyzer
{
    public class PythonAnalyzer /* : IDisposable */
    {
	public const string PythonAnalysisSource = "Python";
	private readonly List<string> _searchPaths = new List<string>();

	/// <summary>
	/// Sets the search paths for this analyzer, invoking callbacks for
	/// any path added or removed
	/// </summary>
	public void SetSearchPaths(IEnumerable<string> paths)
	{
	}
    }
}
