namespace Analyzer.Interpreter
{
    /// <summary>
    /// A member that appears in a module, type, &c
    /// </summary>
    public interface IMember
    {
        PythonMemberType MemberType { get; }
    }
}
