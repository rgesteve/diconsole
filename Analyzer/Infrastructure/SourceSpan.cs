using System;
using System.Diagnostics;

namespace Analyzer
{
  /// <summary>
  /// Stores the location of a span of text in a source file.
  /// </summary>
  [Serializable]
  public struct SourceSpan
  {
#if false
    public SourceSpan(SourceLocation start, SourceLocation end)
    {
    }
#endif

    public SourceSpan(int startLine, int startColumn, int endLine, int endColumn)
    {
    }
  }
}
