using System;
using CodeBase.StaticData;

namespace CodeBase.Presentation.ViewModels
{
    public abstract class ViewModel<TModel> : IViewModel
    where TModel : class
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;
        
        protected TModel _model;
        
        protected virtual UiWindow Window => UiWindow.Curtain;

        public abstract void InvokeOpen();

        public abstract void InvokeClose();
        
        protected virtual void HandleOpenedWindow(UiWindow uiWindow)
        {
            if(Window == uiWindow)
                InvokedOpen?.Invoke();
        }

        protected virtual void HandleClosedWindow(UiWindow uiWindow)
        {
            if(Window == uiWindow)
                InvokedClose?.Invoke();
        }
    }
    
    public abstract class ViewModel<TWindow, TModel> : IViewModel
    where TModel : class
    where TWindow : Enum
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;
        
        protected TModel _model;
        protected readonly IWindowFsm<TWindow> _windowFsm;

        protected virtual TWindow Window { get; }

        protected ViewModel(IWindowFsm<TWindow> windowFsm)
        {
            _windowFsm = windowFsm;
        }

        public abstract void InvokeOpen();

        public abstract void InvokeClose();
        
        protected virtual void HandleOpenedWindow(TWindow uiWindow)
        {
            if(Window.Equals(uiWindow)) InvokedOpen?.Invoke();
        }

        protected virtual void HandleClosedWindow(TWindow uiWindow)
        {
            if(Window.Equals(uiWindow)) InvokedClose?.Invoke();
        }
    }
}