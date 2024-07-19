using Core.Infrastructure;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.Windows;
using Sample.MVVM.View;

namespace Sample.Infrastructure.GameFsm.States
{
    public class MainMenuState : AbstractState, IState
    {
        private const string Scene = "MainMenuScene";
        private readonly SceneLoader _sceneLoader;
        private readonly IWindowFsm _windowFsm;
        private readonly IWindowResolve _windowResolve;

        
        public MainMenuState(IGameStateMachine gameFsm,
            SceneLoader sceneLoader,
            IWindowFsm windowFsm, IWindowResolve windowResolve) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
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
            
            _sceneLoader.Load(Scene, OnLoaded);
        }

        private void OnLoaded()
        {
            _windowResolve.Set<MainMenuView>();
            _windowResolve.Set<SettingsView>();
            _windowFsm.OpenWindow(typeof(MainMenuView));
        }
    }
}