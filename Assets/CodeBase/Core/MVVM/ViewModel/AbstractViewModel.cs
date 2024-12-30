using System;
using Core.Infrastructure.WindowsFsm;

namespace Core.MVVM.ViewModel
{
    public abstract class AbstractViewModel : IViewModel
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;

        protected readonly IWindowFsm _windowFsm;

        protected virtual Type Window { get; }

        protected AbstractViewModel(IWindowFsm windowFsm)
        {
            _windowFsm = windowFsm;
            
            _windowFsm.Opened += HandleOpenedWindow;
            _windowFsm.Closed += HandleClosedWindow;
        }

        public void InvokeOpen()
        {
            OnInvokeOpen();
        }

        public void InvokeClose()
        {
            OnInvokeClose();
        }

        public void CheckInvoked()
        {
            if (_windowFsm.CurrentWindow == null)
                return;
            
            HandleOpenedWindow(_windowFsm.CurrentWindow.GetType());
            HandleClosedWindow(_windowFsm.CurrentWindow.GetType());
        }

        public virtual void OnInvokeOpen()
        {
        }

        public virtual void OnInvokeClose()
        {
        }

        protected virtual void OnDispose()
        {
        }

        protected virtual void HandleOpenedWindow(Type uiWindow)
        {
            if (Window != uiWindow) return;
            InvokedOpen?.Invoke();
        }

        protected virtual void HandleClosedWindow(Type uiWindow)
        {
            if (Window != uiWindow) return;

            InvokedClose?.Invoke();
        }

        public void Dispose()
        {
            OnDispose();
        }
    }
}