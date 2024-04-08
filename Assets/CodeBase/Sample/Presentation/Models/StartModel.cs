using System;
using CodeBase.Core.Infrastructure.GameFSM;
using CodeBase.Core.Infrastructure.GameFSM.States;
using CodeBase.Sample.Infrastructure.GameFsm.States;
using CodeBase.Sample.Services.Scene;
using Cysharp.Threading.Tasks;

namespace CodeBase.Sample.Presentation.Models
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
            // _sceneService
            //     .OnLoadSceneAsync(1);
            _gameFsm.Enter<LoaderState>();
        }
        
        public void OnNextState(int scene)
        {
            // _sceneService
            //     .OnLoadSceneAsync(scene);
            
            _gameFsm.Enter<LoaderState>();
        }
        
        public void OnNextState(Type state)
        {
            _gameFsm.Enter(state);
        }
    }
}