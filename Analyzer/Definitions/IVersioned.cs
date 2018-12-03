using System;
using System.Collections.Generic;

namespace Analyzer
{
    public interface IVersioned
    {
      /// <summary>
      /// The current analysis version of a project entry.
      /// </summary>
      int AnalysisVersion { get; }
    }
}