using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Analyzer.Parsing.Ast
{

  public abstract class ScopeStatement
  {
    private bool _importStar;                   // from module import *
    private bool _unqualifiedExec;              // exec "code"
    private bool _nestedFreeVariables;          // nested function with free variable
    private bool _locals;                       // The scope needs locals dictionary
    // due to "exec" or call to dir, locals, eval, vars...
    private bool _hasLateboundVarSets;          // calls code which can assign to variables
    private bool _containsExceptionHandling;    // true if this block contains a try/with statement

#if false
    private Dictionary<string, PythonVariable> _variables;          // mapping of string to variables
    private ClosureInfo[] _closureVariables;                        // closed over variables, bool indicates if we accessed it in this scope.
        private List<PythonVariable> _freeVars;                         // list of variables accessed from outer scopes
        private List<string> _globalVars;                               // global variables accessed from this scope
        private List<string> _cellVars;                                 // variables accessed from nested scopes
        private List<NameExpression> _nonLocalVars;                             // variables declared as nonlocal within this scope
        private Dictionary<string, List<PythonReference>> _references;        // names of all variables referenced, null after binding completes
        private ScopeStatement _parent;
#endif
  }

}
