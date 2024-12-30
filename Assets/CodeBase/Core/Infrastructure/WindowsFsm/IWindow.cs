using System;

namespace Core.Infrastructure.WindowsFsm
{
    public interface IWindow
    {
        event Action<Type> Opened;
        event Action<Type> Closed;
        
        void Open();
        void Close();
    }
}