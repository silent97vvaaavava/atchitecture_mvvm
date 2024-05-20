using Core.Domain.Providers;
using Core.MVVM.WindowFsm;
using Training.MVVM.WindowFsm;
using Zenject;

namespace Training.Domain.Providers 
{
    public class WindowFsmProvider : IWindowFsmProvider
    {
        private readonly DiContainer _container;
        private IWindowFsm _general;
        private IWindowFsm _local;

        public WindowFsmProvider(DiContainer container)
        {
            _container = container;
        }
        
        public IWindowFsm General => _general ??= _container.Instantiate<WindowFsm>();
        public IWindowFsm Local => _local ??= _container.Instantiate<WindowFsm>();

        public void Set(IWindowFsm windowFsm) => _local = windowFsm;
    }
}