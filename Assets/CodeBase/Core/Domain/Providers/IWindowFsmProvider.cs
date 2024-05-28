using Core.MVVM.Windows;

namespace Core.Domain.Providers
{
    public interface IWindowFsmProvider
    {
        IWindowFsm General { get; }
        IWindowFsm Local { get; }
        void Set(IWindowFsm windowFsm);
    }
}