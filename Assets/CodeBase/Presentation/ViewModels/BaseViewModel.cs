using System;

namespace CodeBase.Presentation.ViewModels
{
    public abstract class BaseViewModel : IViewModel
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;

        protected virtual Type Window { get; }

        public abstract void InvokeOpen();

        public abstract void InvokeClose();
        
        protected virtual void HandleOpenedWindow(Type uiWindow)
        {
            if(Window == uiWindow)
                InvokedOpen?.Invoke();
        }

        protected virtual void HandleClosedWindow(Type uiWindow)
        {
            if(Window == uiWindow)
                InvokedClose?.Invoke();
        }
    }
}