using System;

namespace CodeBase.Services
{
    public interface ISubscribeTable<TChangedValue>
    where TChangedValue : EventArgs
    {
        void Subscribe(Func<string, string> onPath, EventHandler<TChangedValue> evtHandler);
    }
}