using System.Threading.Tasks;
using Core.Infrastructure;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.Windows;
using Cysharp.Threading.Tasks;
using Sample.MVVM.View;

namespace Sample.Infrastructure.GameFsm.States
{
    public class GameplayState : AbstractState, IAsyncState
    {
        private readonly SceneLoader _sceneService;
        private IWindowFsm _windowFsm;

        public GameplayState(IGameStateMachine gameFsm, SceneLoader sceneService, IWindowFsm windowFsm) : base(gameFsm)
        {
            _sceneService = sceneService;
            _windowFsm = windowFsm;
        }

        public override void OnExit()
        {
            
        }

        public async Task OnEnterAsync()
        {
            await _sceneService.LoadScene("GameplayScene");
            _windowFsm.OpenWindow(typeof(GameplayView));
        }
    }
}