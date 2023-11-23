using System;
using CodeBase.StaticData;

namespace CodeBase.Presentation
{
    public sealed class Window : IWindow
    {
        public event Action<UiWindow> Opened;
        public event Action<UiWindow> Closed;
        
        public UiWindow UIWindow { get; }

        public Window(UiWindow uiWindow)
        {
            UIWindow = uiWindow;
        }

        public void Open() => 
            Opened?.Invoke(UIWindow);

        public void Close() => 
            Closed?.Invoke(UIWindow);
    }
}