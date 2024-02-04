namespace Rlyeh;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IApplication : IDisposable
{
    Task<bool> RunAsync(CancellationToken cancellationToken);
}