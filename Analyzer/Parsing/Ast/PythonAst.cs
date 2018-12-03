using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Analyzer.Parsing;

namespace Analyzer.Parsing.Ast
{
  /// <summary>
  /// Top-level AST for all Python code.  Holds onto the body and the
  /// line mapping information.
  /// </summary>  
  public sealed class PythonAst
  {
    private readonly PythonLanguageVersion _langVersion;
    private string _privatePrefix;

    public /* override */ string Name
    {
      get { return "<module>"; }
    }

    /// <summary>
    /// Gets the class name under which this AST was parsed [?].
    /// The class name is appended to any member.
    /// </summary>
    public string PrivatePrefix
    {
      get { return _privatePrefix; }
      internal set { _privatePrefix = value; }
    }
  }

}
