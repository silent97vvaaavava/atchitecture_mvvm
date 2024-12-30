namespace Core.Infrastructure.GameFsm.States
{
    public interface IStatesFactory
    {
        TState Create<TState>()
            where TState : class, IExitableState;
    }
}