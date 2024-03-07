using UnityEngine;

namespace CodeBase.Infrastructure
{
    public abstract class BaseState : IState
    {
        protected readonly IGameFsm GameFsm;

        protected BaseState(IGameFsm gameFsm)
        {
            GameFsm = gameFsm;
        }

        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }
    }
}