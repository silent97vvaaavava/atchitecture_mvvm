using System.Collections;
using Core.Domain.Providers;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Core.MVVM.WindowFsm;
using Cysharp.Threading.Tasks;
using Training.MVVM.View;
using Training.Services;

namespace Training.Infrastructure.GameFsm.States
{
    public class GameplayState : AbstractState
    {
        private readonly SceneService _sceneService;
        private readonly IWindowFsm _windowFsm;

        public GameplayState(IGameFsm gameFsm, SceneService sceneService, IWindowFsmProvider windowFsmProvider) : base(gameFsm)
        {
            _sceneService = sceneService;
            _windowFsm = windowFsmProvider.Local;
        }

        public override void Enter()
        {
            base.Enter();
            _sceneService.OnLoadSceneAsync(1).Forget();
            _windowFsm.OpenWindow(typeof(MainMenuView));
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