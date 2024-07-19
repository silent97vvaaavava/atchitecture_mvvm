using System;

namespace Core.MVVM.Windows
{
    public class Window : IWindow
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;
        public Type UIWindow { get; }
        
        public Window(Type uiWindow) => UIWindow = uiWindow;
        
        public void Open() => Opened?.Invoke(UIWindow);
        public void Close() => Closed?.Invoke(UIWindow);
    }
}