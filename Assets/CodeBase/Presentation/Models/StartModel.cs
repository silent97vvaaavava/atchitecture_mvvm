using CodeBase.Infrastructure;
using CodeBase.Services;

namespace CodeBase.Presentation.Models
{
    public class StartModel
    {
        private readonly IGameFsm _gameFsm;
        private readonly SceneService _sceneService;

        public StartModel(IGameFsm gameFsm, SceneService sceneService)
        {
            _gameFsm = gameFsm;
            _sceneService = sceneService;
        }

        public void OnNextState()
        {
            _sceneService
                .OnLoadSceneAsync(1);
            _gameFsm.Enter<LoaderState>();
        }
    }
}