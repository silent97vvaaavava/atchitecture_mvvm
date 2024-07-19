using Core.Infrastructure.GameFsm.States;

namespace Core.Domain.Factories
{
    public interface IStatesFactory
    {
        TState Create<TState>()
            where TState : class, IExitableState;
    }
}