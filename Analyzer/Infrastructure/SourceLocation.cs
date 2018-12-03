using System;
using System.Diagnostics;

namespace Analyzer
{
  [Serializable]
  public struct SourceLocation : IComparable<SourceLocation>
  {
    private readonly int _index;

    /// <summary>
    /// The index in the source stream the location represents (0-based)
    /// </summary>
    public int Index => _index >= 0 ? _index : throw new InvalidOperationException("Index is not valid");

    /// <summary>
    /// The line in the source stream the location represents (1-based)
    /// </summary>
    public int Line { get; }

    /// <summary>
    /// The column in the source stream the location represents (1-based)
    /// </summary>
    public int Column { get; }

    public int CompareTo(SourceLocation other)
    {
      int c = Line.CompareTo(other.Line);
      if (c == 0) {
        return Column.CompareTo(other.Column);
      }
      return c;
    }
  }
}