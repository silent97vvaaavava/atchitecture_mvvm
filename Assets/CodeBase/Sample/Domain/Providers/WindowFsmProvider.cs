using Core.Domain.Providers;
using Core.MVVM.Windows;

namespace Sample.Domain.Providers
{
    public class WindowFsmProvider : IWindowFsmProvider
    {
        private readonly IWindowFsm _general;
        private IWindowFsm _local;

        public IWindowFsm General => _general;

        public IWindowFsm Local => _local;

        public WindowFsmProvider(IWindowFsm general)
        {
            _general = general;
        }

        public void Set(IWindowFsm windowFsm)
        {
            _local = windowFsm;
        }
    }
}