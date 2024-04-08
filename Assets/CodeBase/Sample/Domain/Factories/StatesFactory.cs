using CodeBase.Core.Domain.Factories;
using CodeBase.Core.Infrastructure.GameFSM.States;
using Zenject;

namespace CodeBase.Sample.Domain.Factories
{
    public class StatesFactory : IStatesFactory
    {
        private readonly DiContainer _diContainer;

        public StatesFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public TState Create<TState>()
        where TState : class, IState
        {
            return _diContainer.Instantiate<TState>();
        }
    }
}