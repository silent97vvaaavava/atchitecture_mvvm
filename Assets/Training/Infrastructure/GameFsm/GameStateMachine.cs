using Core.Domain.Factories;
using Core.Infrastructure.GameFsm;
using Training.Infrastructure.GameFsm.States;
using UnityEngine;
using IInitializable = Zenject.IInitializable;

namespace Training.Infrastructure.GameFsm
{
    public class GameStateMachine : BaseGameFsm, IInitializable
    {
        public GameStateMachine(IStatesFactory factory) : base(factory)
        {
        }

        public void Initialize()
        {
            _states.TryAdd(typeof(MainMenuState), _factory.Create<MainMenuState>());
            _states.TryAdd(typeof(GameplayState), _factory.Create<GameplayState>());
            Enter<MainMenuState>();
        }
    }
}