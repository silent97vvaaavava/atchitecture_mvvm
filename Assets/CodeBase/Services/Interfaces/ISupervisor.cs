using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.Services.Interfaces
{
    public interface ISupervisor<TEvent>
        where TEvent : EventArgs
    {
        Dictionary<Type, EventHandler<TEvent>> Supervisors { get; }

        void AddSupervisor(Type type, EventHandler<TEvent> callback);
        bool TryAddSupervisor(Type type, EventHandler<TEvent> callback);

        Task SubscribeSupervisorAsync(IProgress<int> progress = null);
    }
}