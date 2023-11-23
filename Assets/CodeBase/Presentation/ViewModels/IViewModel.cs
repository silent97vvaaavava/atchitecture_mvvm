using System;

namespace CodeBase.Presentation.ViewModels
{
    public interface IViewModel
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;
        
        void InvokeOpen();
        void InvokeClose();
    }
}