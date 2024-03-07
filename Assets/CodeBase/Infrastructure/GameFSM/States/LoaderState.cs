using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class LoaderState : BaseState
    {
        public LoaderState(
            IGameFsm gameFsm
        ) : base(gameFsm)
        {
        }

        public override async void Enter()
        {
        }

        public override void Exit()
        {
            GameFsm.Enter<GameplayState>();
        }
    }
}