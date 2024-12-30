using System;

namespace Core.Infrastructure.WindowsFsm
{
    public interface IWindowFsm
    {
        event Action<Type> Opened;
        event Action<Type> Closed;
        
        IWindow CurrentWindow { get; }

        void OpenWindow(Type window, bool inHistory);
        void OpenWindow(Type window);
        
        void CloseWindow(Type window);
        void CloseWindow();
        
        void ClearHistory();
    }
}