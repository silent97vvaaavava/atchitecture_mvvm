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
}