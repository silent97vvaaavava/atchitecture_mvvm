using System;

namespace Core.MVVM.ViewModel
{
    public interface IViewModel
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;
        
        void InvokeOpen();
        void InvokeClose();
    }
}