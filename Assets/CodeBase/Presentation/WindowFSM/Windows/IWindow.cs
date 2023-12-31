using System;
using CodeBase.StaticData;

namespace CodeBase.Presentation
{
    public interface IWindow
    {
        event Action<UiWindow> Opened;
        event Action<UiWindow> Closed;
        
        UiWindow UIWindow { get; }
        
        void Open();
        void Close();
    }
    
    public interface IWindow<out TWindow>
    where TWindow : Enum
    {
        event Action<TWindow> Opened;
        event Action<TWindow> Closed;
        
        TWindow UIWindow { get; }
        
        void Open();
        void Close();
    }
}