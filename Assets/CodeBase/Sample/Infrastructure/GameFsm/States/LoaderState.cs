using System.Collections;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using UnityEngine;

namespace Sample.Infrastructure.GameFsm.States
{
    public class LoaderState : AbstractState
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

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            Debug.Log("Exit Loader");
        }
    }
}