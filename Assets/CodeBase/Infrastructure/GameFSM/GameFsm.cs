using System;
using System.Collections.Generic;
using CodeBase.Helpers;
using CodeBase.Services;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameFsm : IGameFsm, IInitializable
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        public GameFsm()
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(InitializeState)] = new InitializeState(this),
                [typeof(LoaderState)] = new LoaderState(this),
                [typeof(GameplayState)] = new GameplayState(this),
                [typeof(PauseState)] = new PauseState(this)
            };
        }
        
        public void Enter<TState>() 
            where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state?.Enter();
        }

        private TState ChangeState<TState>()
            where TState : class, IExitableState
        {
            TState state = GetState<TState>();
            _activeState?.Exit();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() 
            where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;

        public void Initialize()
        {
            Enter<InitializeState>();
        }
    }
}