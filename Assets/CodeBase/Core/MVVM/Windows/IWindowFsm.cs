using System;

namespace Core.MVVM.Windows
{
    public interface IWindowFsm
    {
        event Action<Type> Opened;
        event Action<Type> Closed;
        
        void OpenWindow(Type window, bool inHistory);
        void OpenWindow(Type window);
        
        void CloseWindow(Type window);
        void CloseWindow();
        
        void ClearHistory();
    }
}