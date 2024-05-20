using Core.Domain.Factories;
using Core.Infrastructure.GameFsm;
using Training.Infrastructure.GameFsm.States;

namespace Training.Infrastructure.GameFsm
{
    public class GameStateMachine : BaseGameFsm
    {
        public GameStateMachine(IStatesFactory factory) : base(factory)
        {
        }
        
        public void RegisterStates()
        {
            _states.Add(typeof(MainMenuScreenState), _factory.Create<MainMenuScreenState>());
            _states.Add(typeof(GameScreenState), _factory.Create<GameScreenState>());
        }
    }
}