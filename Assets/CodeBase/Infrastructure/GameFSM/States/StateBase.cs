using UnityEngine;

namespace CodeBase.Infrastructure
{
    public abstract class StateBase : IState
    {
        protected readonly IGameFsm GameFsm;

        protected StateBase(IGameFsm gameFsm)
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