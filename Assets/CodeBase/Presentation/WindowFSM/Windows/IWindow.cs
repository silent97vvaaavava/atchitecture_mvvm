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
}