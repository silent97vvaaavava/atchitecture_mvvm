using System;

namespace Core.Infrastructure.WindowsFsm
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