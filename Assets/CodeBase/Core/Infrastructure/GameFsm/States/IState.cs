namespace CodeBase.Core.Infrastructure.GameFSM.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}