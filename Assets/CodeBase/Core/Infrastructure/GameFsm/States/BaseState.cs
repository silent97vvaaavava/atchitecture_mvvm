namespace CodeBase.Core.Infrastructure.GameFSM.States
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