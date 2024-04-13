using System;
using Core.Infrastructure.GameFsm;
using Sample.Infrastructure.GameFsm.States;
using Sample.Services.Scene;

namespace Sample.Presentation.Models
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