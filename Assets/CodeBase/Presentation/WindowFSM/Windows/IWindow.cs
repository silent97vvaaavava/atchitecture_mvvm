using System;
using CodeBase.StaticData;

namespace CodeBase.Presentation
{
    public interface IWindow
    {
        event Action<Type> Opened;
        event Action<Type> Closed;
        
        Type UIWindow { get; }
        
        void Open();
        void Close();
    }
}