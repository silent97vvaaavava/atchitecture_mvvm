using System.Collections;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;

namespace Sample.Infrastructure.GameFsm.States
{
    public class PauseState : AbstractState
    {
        public PauseState(IGameFsm gameFsm) : base(gameFsm)
        {
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }
    }
}