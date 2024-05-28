namespace Core.Infrastructure.GameFsm.States
{
    public abstract class AbstractState : IExitableState
    {
        protected readonly IGameStateMachine GameStateMachine;
        
        protected AbstractState(IGameStateMachine gameStateMachine) => 
            GameStateMachine = gameStateMachine;

        public abstract void OnExit();
    }
}