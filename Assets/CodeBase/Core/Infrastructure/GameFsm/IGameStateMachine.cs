using System;
using Core.Infrastructure.GameFsm.States;

namespace Core.Infrastructure.GameFsm
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IState;
        void Enter(Type type);
        
        void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadedState<TPayload>;

        void EnterAsync<TState>() where TState : class, IAsyncState;
    }
}