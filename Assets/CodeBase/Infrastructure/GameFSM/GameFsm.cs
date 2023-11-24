using System;
using System.Collections.Generic;
using CodeBase.Helpers;
using CodeBase.Services;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameFsm : IGameFsm, IInitializable
    {
        private readonly ILoadingCurtain _curtain;
        private readonly InternetReachability _internetReachability;
        private readonly DatabaseService _dbService;
        
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        public GameFsm(
            ILoadingCurtain curtain,
            InternetReachability internetReachability,
            DatabaseService dbService
            )
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(StateInitialize)] = new StateInitialize(this, internetReachability, curtain, dbService),
                [typeof(StateLoader)] = new StateLoader(this, dbService, curtain),
                [typeof(StateGameplay)] = new StateGameplay(this),
                [typeof(StatePause)] = new StatePause(this)
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
            _curtain?.Show();
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;

        public void Initialize()
        {
            Enter<StateInitialize>();
        }
    }
}