using System;

// using Analyzer.Infrastructure;

namespace Analyzer.Parsing
{
    /// <summary>
    /// Specifies the version of the Python language to be used for parsing.
    /// 
    /// Referred to from C++ in PyDebugAttach.cpp and python.h and must be kept in sync
    /// </summary>
    public enum PythonLanguageVersion {
        None = 0,
        V24 = 0x0204,
        V25 = 0x0205,
        V26 = 0x0206,
        V27 = 0x0207,
        V30 = 0x0300,
        V31 = 0x0301,
        V32 = 0x0302,
        V33 = 0x0303,
        V34 = 0x0304,
        V35 = 0x0305,
        V36 = 0x0306,
        V37 = 0x0307,
        V38 = 0x0308
    }
}