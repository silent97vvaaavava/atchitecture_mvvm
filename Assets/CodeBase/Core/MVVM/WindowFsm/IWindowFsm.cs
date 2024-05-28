using System;

namespace Core.MVVM.WindowFsm
{
    public interface IWindowFsm
    {
        event Action<Type> Opened;
        event Action<Type> Closed;
        
        Type CurrentWindow { get; }
        bool IsOpenWindow { get; }
        
        void OpenWindow(Type windowType);
        void OpenOneWindow(Type window);
        void CloseWindow(Type type);
        void CloseCurrentWindow();
        void ClearHistory();
    }
}