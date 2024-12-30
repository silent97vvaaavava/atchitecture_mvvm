using System;
using System.Collections.Generic;
using Core.Infrastructure.GameFsm.States;

namespace Core.Infrastructure.GameFsm
{
    public abstract class GameStateMachineBase : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();
        private readonly IStatesFactory _statesFactory;
        private IExitableState _currentState;
        
        public GameStateMachineBase(IStatesFactory statesFactory)
        {
            _statesFactory = statesFactory;
        }

        public abstract void Initialize();

        public virtual void Enter<TState>() 
            where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state?.OnEnter();
        }
        
        public virtual void Enter(Type type) 
        {
            IState state = _states[type] as IState;
            state?.OnEnter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> state = ChangeState<TState>();
            state.OnEnter(payload);
        }

        public async void EnterAsync<TState>() where TState : class, IAsyncState
        {
            IAsyncState state = ChangeState<TState>();
            await state?.OnEnterAsync()!;
        }
        
        public void AddState<T>() where T : class, IExitableState =>
        _states.Add(typeof(T), _statesFactory.Create<T>());
        
        protected virtual TState ChangeState<TState>()
            where TState : class, IExitableState
        {
            _currentState?.OnExit();
            TState state = GetState<TState>();
            _currentState = state;
            return state;
        }

        protected virtual TState GetState<TState>() 
            where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;

    }
}