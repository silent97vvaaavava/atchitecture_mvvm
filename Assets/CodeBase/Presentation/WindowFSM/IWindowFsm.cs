using System;

namespace CodeBase.Presentation
{
    public interface IWindowFsm
    {
        event Action<Type> Opened;
        event Action<Type> Closed;
        
        Type CurrentWindow { get; }
        bool IsOpenWindow { get; }
        
        void OpenWindow(Type window);
        void OpenOneWindow(Type window);
        void CloseWindow(Type window);
        void CloseCurrentWindow();
        void ClearHistory();
    }
}