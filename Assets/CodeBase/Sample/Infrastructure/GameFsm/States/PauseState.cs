using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;

namespace Sample.Infrastructure.GameFsm.States
{
    public class PauseState : AbstractState, IState
    {
        public PauseState(IGameStateMachine gameStateMachine) : base(gameStateMachine)
        {
        }


        public override void OnExit()
        {
            
        }

        public void OnEnter()
        {
        }
    }
}