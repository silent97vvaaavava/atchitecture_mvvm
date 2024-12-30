using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.Samples.Infrastructure.GameFsm.States;

namespace Core.Samples.Infrastructure.GameFsm
{
    public class GameStateMachine : GameStateMachineBase
    {
        public GameStateMachine(IStatesFactory statesFactory) : base(statesFactory)
        {
        }

        public override void Initialize()
        {
            StateResolve();
            Enter<BootstrapState>();
        }

        private void StateResolve()
        {
            AddState<BootstrapState>();
            AddState<MenuState>();
        }
    }
}