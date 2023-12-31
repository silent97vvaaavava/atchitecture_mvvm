using System;
using CodeBase.StaticData;

namespace CodeBase.Services.Interfaces
{
    public interface IStored
    {
        event Action OnSave;
        event Action<Func<string,string>, EventHandler<EventArgs>> OnSubscribe;
        TableType Table { get; }
    }
}