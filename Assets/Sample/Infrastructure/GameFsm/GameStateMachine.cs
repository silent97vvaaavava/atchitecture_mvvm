using Core.Domain.Factories;
using Core.Infrastructure.GameFsm;
using Sample.Infrastructure.GameFsm.States;
using IInitializable = Zenject.IInitializable;

namespace Sample.Infrastructure.GameFsm
{
    public class GameStateMachine : AbstractGameStateMachine, IInitializable
    {
        public GameStateMachine(IStatesFactory factory) : base(factory)
        {
        }

        public void Initialize()
        {
            _states.TryAdd(typeof(MainMenuState), _factory.Create<MainMenuState>());
            _states.TryAdd(typeof(GameplayState), _factory.Create<GameplayState>());
            EnterAsync<MainMenuState>();
        }
    }
}