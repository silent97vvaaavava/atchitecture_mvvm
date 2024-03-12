using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class StartState : BaseState
    {
        public StartState(
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
            // GameFsm?.Enter<LoaderState>();
        }
    }
}