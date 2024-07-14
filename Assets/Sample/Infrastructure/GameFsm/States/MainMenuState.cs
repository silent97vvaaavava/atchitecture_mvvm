using System.Collections;
using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.WindowFsm;
using Cysharp.Threading.Tasks;
using Sample.MVVM.View;
using Sample.Services;

namespace Sample.Infrastructure.GameFsm.States
{
    public class MainMenuState : AbstractState
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IWindowFsmProvider _windowFsmProvider;
        private IWindowFsm _windowFsm;
        
        private bool _isCompleted;
        
        public MainMenuState(IGameFsm gameFsm, SceneLoader sceneLoader, IWindowFsmProvider windowFsmProvider) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
            _windowFsmProvider = windowFsmProvider;
        }
        
        public override async void Enter()
        {
            base.Enter();   
            await _sceneLoader.LoadScene("MainMenuScene");
            _windowFsm = _windowFsmProvider.Local;
            _windowFsm.OpenWindow(typeof(MainMenuView));
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            _windowFsm.CloseWindow(typeof(MainMenuView));
            base.Exit();
        }
    }
}