using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class InitializeState : BaseState
    {
        public InitializeState(
            IGameFsm gameFsm
            ) : base(gameFsm)
        {
        }
        
        public override void Enter()
        { 
            Debug.Log("first state");
        }

        public override void Exit()
        {
            GameFsm?.Enter<LoaderState>();
        }
    }
}