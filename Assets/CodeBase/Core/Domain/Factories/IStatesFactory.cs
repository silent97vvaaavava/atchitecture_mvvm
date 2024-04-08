using CodeBase.Core.Infrastructure.GameFSM.States;

namespace CodeBase.Core.Domain.Factories
{
    public interface IStatesFactory
    {
        TState Create<TState>()
            where TState : class, IState;
    }
}