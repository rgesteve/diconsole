using System;
using System.Collections.Generic;
using System.IO;

namespace Analyzer
{
  public interface IDocument
  {
    TextReader ReadDocument(int part, out int version);
    Stream ReadDocumentBytes(int part, out int version);
    int GetDocumentVersion(int part);
    IEnumerable<int> DocumentParts { get; }
    Uri DocumentUri { get; }

    void UpdateDocument(int part, DocumentChangeSet changes);
    void ResetDocument(int version, string content);
  }
}
