using Core.Infrastructure;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.Windows;
using Sample.MVVM.View;

namespace Sample.Infrastructure.GameFsm.States
{
    public class MainMenuState : AbstractState, IState
    {
        private readonly SceneLoader _sceneLoader;
        private IWindowFsm _windowFsm;
        private IWindowResolve _windowResolve;
        private bool _isCompleted;
        
        public MainMenuState(IGameStateMachine gameFsm,
            SceneLoader sceneLoader,
            IWindowFsm windowFsm,
            IWindowResolve windowResolve) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
            _windowFsm = windowFsm;
            _windowResolve = windowResolve;
        }
        
        public override void OnExit()
        {
            _windowFsm.CloseWindow(typeof(MainMenuView));
        }

        public void OnEnter()
        {
            _windowFsm.ClearHistory();
            _windowResolve.CleanUp();
            _windowResolve.Set<MainMenuView>();
            _windowResolve.Set<SettingsView>();
            
            _sceneLoader.Load("MainMenuScene", OnLoaded);
        }

        private void OnLoaded() 
            => _windowFsm.OpenWindow(typeof(MainMenuView));
    }
}