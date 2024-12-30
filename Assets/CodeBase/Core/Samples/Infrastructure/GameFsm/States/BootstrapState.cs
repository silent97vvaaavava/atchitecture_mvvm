using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;

namespace Core.Samples.Infrastructure.GameFsm.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void OnExit()
        {
            
        }

        public void OnEnter()
        {
            _gameStateMachine.Enter<MenuState>();
        }
    }
}