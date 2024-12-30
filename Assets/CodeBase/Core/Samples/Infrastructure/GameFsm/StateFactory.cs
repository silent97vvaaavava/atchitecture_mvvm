using Core.Infrastructure.GameFsm.States;
using Zenject;

namespace Core.Samples.Infrastructure.GameFsm
{
    public class StateFactory : IStatesFactory
    {
        private readonly DiContainer _diContainer;

        public StateFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public TState Create<TState>() where TState : class, IExitableState
        {
            TState state = _diContainer.Instantiate<TState>();
            return state;
        }
    }
}