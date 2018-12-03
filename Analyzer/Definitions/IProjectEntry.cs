using System;
using System.Collections.Generic;

using Analyzer.Interpreter;

namespace Analyzer
{
  /// <summary>
  /// Represents a file which is capable of being analyzed.  Can be cast
  /// to other project entry types for more functionality.  See also
  /// IPythonProjectEntry and IXamlProjectEntry.
  /// </summary>
  public interface IProjectEntry : IAnalyzable, IVersioned, IDisposable
  {
      /// <summary>
      /// True if the project entry has been parsed and analyzed.      
      /// </summary>
      bool IsAnalyzed { get; }

      /// <summary>
      /// The project entry's filepath
      /// </summary>
      string FilePath { get; }

      /// <summary>
      /// The document's unique identifier.
      /// How to get from project entry to document?
      /// </summary>
      Uri DocumentUri { get; }

      /// <summary>
      /// Storage of arbitrary properties associated with the project entry.
      /// </summary>
      Dictionary<object, object> Properties { get; }

      IModuleContext AnalysisContext { get; }
  }

}
