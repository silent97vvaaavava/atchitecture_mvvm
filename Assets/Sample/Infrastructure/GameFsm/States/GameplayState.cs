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
    public class GameplayState : AbstractState
    {
        private readonly SceneLoader _sceneService;
        private readonly IWindowFsmProvider _windowFsmProvider;
        private IWindowFsm _windowFsm;

        public GameplayState(IGameFsm gameFsm, SceneLoader sceneService, IWindowFsmProvider windowFsmProvider) : base(gameFsm)
        {
            _sceneService = sceneService;
            _windowFsmProvider = windowFsmProvider;
        }

        public override async void Enter()
        {
            base.Enter();
            await _sceneService.LoadScene("GameplayScene");
            _windowFsm = _windowFsmProvider.Local;
            _windowFsm.OpenWindow(typeof(GameplayView));
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}