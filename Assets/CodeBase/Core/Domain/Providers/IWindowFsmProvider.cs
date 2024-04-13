using Core.MVVM.WindowFsm;

namespace Core.Domain.Providers
{
    public interface IWindowFsmProvider
    {
        IWindowFsm General { get; }
        IWindowFsm Local { get; }
        void Set(IWindowFsm windowFsm);
    }
}