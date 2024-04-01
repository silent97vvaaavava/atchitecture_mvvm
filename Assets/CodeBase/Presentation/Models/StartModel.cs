using CodeBase.Infrastructure;
using CodeBase.Services;
using Cysharp.Threading.Tasks;

namespace CodeBase.Presentation.Models
{
    public class StartModel // ToDo: Change to Scene Model 
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
        
        public void OnNextState(int scene)
        {
            _sceneService
                .OnLoadSceneAsync(scene);
            
            _gameFsm.Enter<LoaderState>();
        }
    }
}