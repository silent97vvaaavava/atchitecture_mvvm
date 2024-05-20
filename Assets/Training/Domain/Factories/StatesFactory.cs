using Core.Domain.Factories;
using Core.Infrastructure.GameFsm.States;
using Zenject;

namespace Training.Domain.Factories
{
    public class StatesFactory : IStatesFactory
    {
        private readonly DiContainer _diContainer;

        public StatesFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public TState Create<TState>() where TState : class, IState
        {
            return _diContainer.Instantiate<TState>();
        }
    }
}