using CodeBase.Core.Infrastructure.GameFSM;
using CodeBase.Core.Infrastructure.GameFSM.States;

namespace CodeBase.Sample.Infrastructure.GameFsm.States
{
    public class PauseState : BaseState
    {
        public PauseState(IGameFsm gameFsm) : base(gameFsm)
        {
        }
    }
}