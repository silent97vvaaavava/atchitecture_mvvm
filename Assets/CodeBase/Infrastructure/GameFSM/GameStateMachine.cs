using System;
using System.Collections.Generic;
using CodeBase.Helpers;
using CodeBase.Services;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameStateMachine : IGameStateMachine, IInitializable
    {
        private readonly ILoadingCurtain _curtain;
        private readonly InternetReachability _internetReachability;
        private readonly DatabaseService _dbService;
        
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        public GameStateMachine(
            ILoadingCurtain curtain,
            InternetReachability internetReachability,
            DatabaseService dbService
            )
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(InitializeState)] = new InitializeState(this, internetReachability, curtain, dbService),
                [typeof(LoaderState)] = new LoaderState(this, dbService, curtain),
                [typeof(GameplayState)] = new GameplayState(this),
                [typeof(PauseState)] = new PauseState(this)
            };
            _curtain = curtain;
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
            // _activeState?.Exit();
            _curtain?.Show();
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;

        public void Initialize()
        {
            Enter<InitializeState>();
        }
    }
}