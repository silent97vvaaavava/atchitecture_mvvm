using System;
using Core.Infrastructure.GameFsm.States;

namespace Core.Infrastructure.GameFsm
{
    public interface IGameFsm
    {
        void Enter<TState>() where TState : class, IState;
        void Enter(Type type);
    }
}