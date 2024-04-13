using Core.Domain.Factories;
using Core.Infrastructure.GameFsm;
using Sample.Infrastructure.GameFsm.States;
using UnityEngine;
using Zenject;

namespace Sample.Infrastructure.GameFsm
{
    public class GameFsm : BaseGameFsm, IInitializable
    {
        public GameFsm(IStatesFactory factory) : base(factory)
        {
        }
        
        public virtual void Initialize()
        {
            Debug.Log("Initialize State Machine");
            _states.TryAdd(typeof(StartState), _factory.Create<StartState>());
            _states.TryAdd(typeof(LoaderState), _factory.Create<LoaderState>());
            _states.TryAdd(typeof(GameplayState), _factory.Create<GameplayState>());
            _states.TryAdd(typeof(PauseState), _factory.Create<PauseState>());
            Enter<StartState>();
        }
    }
}