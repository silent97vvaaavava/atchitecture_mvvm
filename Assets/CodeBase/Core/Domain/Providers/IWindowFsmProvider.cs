using CodeBase.Core.MVVM.WindowFsm;

namespace CodeBase.Core.Domain.Providers
{
    public interface IWindowFsmProvider
    {
        IWindowFsm General { get; }
        IWindowFsm Local { get; }
        void Set(IWindowFsm windowFsm);
    }
}