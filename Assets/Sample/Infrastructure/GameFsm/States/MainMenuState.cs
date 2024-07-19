using System.Threading.Tasks;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.Windows;
using Cysharp.Threading.Tasks;
using Sample.MVVM.View;
using Sample.Services;

namespace Sample.Infrastructure.GameFsm.States
{
    public class MainMenuState : AbstractState, IAsyncState
    {
        private readonly SceneLoader _sceneLoader;
        private IWindowFsm _windowFsm;
        
        private bool _isCompleted;
        
        public MainMenuState(IGameStateMachine gameFsm, SceneLoader sceneLoader, IWindowFsm windowFsm) : base(gameFsm)
        {
            _sceneLoader = sceneLoader;
            _windowFsm = windowFsm;
        }
        
        public override void OnExit()
        {
            _windowFsm.CloseWindow(typeof(MainMenuView));
        }

        public async Task OnEnterAsync()
        {
            await _sceneLoader.LoadScene("MainMenuScene");
            _windowFsm.OpenWindow(typeof(MainMenuView));
        }
    }
}