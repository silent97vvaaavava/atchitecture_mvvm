namespace CodeBase.Infrastructure
{
    public abstract class BaseState : IState
    {
        protected readonly IGameStateMachine _gameStateMachine;

        protected BaseState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public virtual void Enter()
        {
            
        }

        public virtual void Exit()
        {
            
        }
    }
}