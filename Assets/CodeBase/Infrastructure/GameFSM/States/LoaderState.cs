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
            Debug.Log("Enter Loader");
            GameFsm?.Enter<GameplayState>();
        }

        public override void Exit()
        {
            Debug.Log("Exit Loader");
        }
    }
}