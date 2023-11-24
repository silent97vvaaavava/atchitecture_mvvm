namespace CodeBase.Infrastructure
{
    public interface IGameFsm
    {
        void Enter<TState>() where TState : class, IState;
    }
}