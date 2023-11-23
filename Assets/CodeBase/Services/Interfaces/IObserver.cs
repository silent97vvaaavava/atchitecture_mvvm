using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.Services.Interfaces
{
    public interface IObserver<TEvent>
        where TEvent : EventArgs
    {
        Dictionary<Type, EventHandler<TEvent>> Observers { get; }
        
        void AddObserver(Type type, EventHandler<TEvent> callback);
        bool TryAddObserver(Type type, EventHandler<TEvent> callback);

        Task SubscribeObserverAsync(IProgress<int> progress = null);
    }
}