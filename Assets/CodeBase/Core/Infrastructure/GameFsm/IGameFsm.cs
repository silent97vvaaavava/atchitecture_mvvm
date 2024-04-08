using System;
using CodeBase.Core.Infrastructure.GameFSM.States;

namespace CodeBase.Core.Infrastructure.GameFSM
{
    public interface IGameFsm
    {
        void Enter<TState>() where TState : class, IState;
        void Enter(Type type);
    }
}