using CodeBase.Core.Domain.Factories;
using CodeBase.Core.Infrastructure.GameFSM;
using CodeBase.Sample.Infrastructure.GameFsm.States;
using Zenject;

namespace CodeBase.Sample.Infrastructure.GameFsm
{
    public class GameFsm : BaseGameFsm, IInitializable
    {
        public GameFsm(IStatesFactory factory) : base(factory)
        {
        }
        
        public virtual void Initialize()
        {
            _states.TryAdd(typeof(StartState), _factory.Create<StartState>());
            _states.TryAdd(typeof(LoaderState), _factory.Create<LoaderState>());
            _states.TryAdd(typeof(GameplayState), _factory.Create<GameplayState>());
            _states.TryAdd(typeof(PauseState), _factory.Create<PauseState>());
            Enter<StartState>();
        }
    }
}