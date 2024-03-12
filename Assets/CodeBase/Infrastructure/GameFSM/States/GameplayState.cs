using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameplayState : BaseState
    {
        public GameplayState(IGameFsm gameFsm) : base(gameFsm)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter Game");
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}