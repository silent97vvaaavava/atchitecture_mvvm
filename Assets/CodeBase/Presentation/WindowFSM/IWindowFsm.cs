using System;
using CodeBase.StaticData;

namespace CodeBase.Presentation
{
    public interface IWindowFsm
    {
        event Action<UiWindow> Opened;
        event Action<UiWindow> Closed;
        
        UiWindow CurrentWindow { get; }
        bool IsOpenWindow { get; }
        
        void OpenWindow(UiWindow window);
        void OpenOneWindow(UiWindow window);
        void CloseWindow(UiWindow window);
        void CloseCurrentWindow();
        void ClearHistory();
    }
}