using System.Threading;

namespace Analyzer
{
  public interface IAnalyzable
  {
    void Analyze(CancellationToken cancel);
  }
}
