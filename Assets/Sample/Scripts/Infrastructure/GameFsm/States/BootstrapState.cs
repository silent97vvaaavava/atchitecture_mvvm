using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;

namespace Sample.Infrastructure.GameFsm.States
{
    public class BootstrapState : AbstractState, IState
    {
        public BootstrapState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }

        public void OnEnter()
        {
            GameStateMachine
                .Enter<MainMenuState>();
        }

        public override void OnExit()
        {
            
        }
    }
}