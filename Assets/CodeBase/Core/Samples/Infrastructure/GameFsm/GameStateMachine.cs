using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;

namespace Core.Samples.Infrastructure.GameFsm
{
    public class GameStateMachine : GameStateMachineBase
    {
        public GameStateMachine(IStatesFactory statesFactory) : base(statesFactory)
        {
        }
    }
}