using Core.Infrastructure;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.Windows;
using Sample.MVVM.View;

namespace Sample.Infrastructure.GameFsm.States
{
    public class GameplayState : AbstractState, IState
    {
        private const string Scene = "GameplayScene";
        private readonly SceneLoader _sceneService;
        private readonly IWindowFsm _windowFsm;
        private readonly IWindowResolve _windowResolve;
        
        public GameplayState(IGameStateMachine gameFsm,
            SceneLoader sceneService,
            IWindowFsm windowFsm,
            IWindowResolve windowResolve) : base(gameFsm)
        {
            _sceneService = sceneService;
            _windowFsm = windowFsm;
            _windowResolve = windowResolve;
        }

        public override void OnExit()
        {
            _windowFsm.ClearHistory();
            _windowResolve.CleanUp();
        }

        public void OnEnter()
        {
            
            
            _sceneService
                .Load(Scene, OnLoaded);
        }

        private void OnLoaded()
        {
            _windowResolve.Set<GameplayView>();
            _windowFsm.OpenWindow(typeof(GameplayView));
        }
    }
}