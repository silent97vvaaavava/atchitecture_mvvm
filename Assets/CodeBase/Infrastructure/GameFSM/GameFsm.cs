using System;
using System.Collections.Generic;
using CodeBase.Helpers;
using CodeBase.Infrastructure.Factories;
using CodeBase.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameFsm : IGameFsm, IInitializable
    {
        private readonly StatesFactory _factory;
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        public GameFsm(StatesFactory factory)
        {
            _factory = factory;
            _states = new Dictionary<Type, IExitableState>();
        }
        
        public void Enter<TState>() 
            where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state?.Enter();
        }
        
        public void Enter(Type type) 
        {
            IState state = _states[type] as IState;
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
            _states.TryAdd(typeof(StartState), _factory.Create<StartState>());
            _states.TryAdd(typeof(LoaderState), _factory.Create<LoaderState>());
            _states.TryAdd(typeof(GameplayState), _factory.Create<GameplayState>());
            _states.TryAdd(typeof(PauseState), _factory.Create<PauseState>());
            Debug.Log(_states.Count);
            Enter<StartState>();
        }
    }
}