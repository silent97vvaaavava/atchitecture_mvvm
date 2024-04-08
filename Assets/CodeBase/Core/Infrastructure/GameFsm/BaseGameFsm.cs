using System;
using System.Collections.Generic;
using CodeBase.Core.Domain.Factories;
using CodeBase.Core.Infrastructure.GameFSM.States;

namespace CodeBase.Core.Infrastructure.GameFSM
{
    public abstract class BaseGameFsm : IGameFsm
    {
        protected readonly IStatesFactory _factory;
        protected readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        public BaseGameFsm(IStatesFactory factory)
        {
            _factory = factory;
            _states = new Dictionary<Type, IExitableState>();
        }
        
        public virtual void Enter<TState>() 
            where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state?.Enter();
        }
        
        public virtual void Enter(Type type) 
        {
            IState state = _states[type] as IState;
            state?.Enter();
        }

        protected virtual TState ChangeState<TState>()
            where TState : class, IExitableState
        {
            TState state = GetState<TState>();
            _activeState?.Exit();
            _activeState = state;
            return state;
        }

        protected virtual TState GetState<TState>() 
            where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;

    }
}