using System;
using CodeBase.Core.MVVM.WindowFsm;

namespace CodeBase.Sample.Presentation.WindowFSM.Windows
{
    public sealed class Window : IWindow
    {
        public event Action<Type> Opened;
        public event Action<Type> Closed;
        
        public Type UIWindow { get; }

        public Window(Type uiWindow)
        {
            UIWindow = uiWindow;
        }

        public void Open() => 
            Opened?.Invoke(UIWindow);

        public void Close() => 
            Closed?.Invoke(UIWindow);
    }
}