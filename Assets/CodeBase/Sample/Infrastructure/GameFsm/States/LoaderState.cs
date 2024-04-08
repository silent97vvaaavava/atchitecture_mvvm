using CodeBase.Core.Infrastructure.GameFSM;
using CodeBase.Core.Infrastructure.GameFSM.States;
using UnityEngine;

namespace CodeBase.Sample.Infrastructure.GameFsm.States
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