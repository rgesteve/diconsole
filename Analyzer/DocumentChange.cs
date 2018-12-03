using System.Collections.Generic;
using System.Linq;

using Analyzer.Parsing.Ast;

namespace Analyzer
{
  public sealed class DocumentChangeSet
  {
    public int FromVersion { get; }
    public int ToVersion   { get; }
    public IReadOnlyCollection<DocumentChange> Changes { get; }

    public DocumentChangeSet(int fromVersion, int toVersion, IEnumerable<DocumentChange> changes)
    {
      FromVersion = fromVersion;
      ToVersion = toVersion;
      Changes = changes.ToArray();
    }
  }

  public sealed class DocumentChange
  {
    public string InsertedText { get; set; }
    // public SourceSpan ReplacedSpan { get; set; }
    public bool WholeBuffer { get; set; }
  }
}

