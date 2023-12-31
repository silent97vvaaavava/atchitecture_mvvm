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
    
    public interface IWindowFsm<TWindow>
    where TWindow : Enum
    {
        event Action<TWindow> Opened;
        event Action<TWindow> Closed;
        
        TWindow CurrentWindow { get; }
        bool IsOpenWindow { get; }
        
        void OpenWindow(TWindow window);
        void OpenOneWindow(TWindow window);
        void CloseWindow(TWindow window);
        void CloseCurrentWindow();
        void ClearHistory();
    }
}