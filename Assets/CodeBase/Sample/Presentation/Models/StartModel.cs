using System;
using Core.Infrastructure.GameFsm;
using Sample.Infrastructure.GameFsm.States;
using Sample.Services.Scene;

namespace Sample.Presentation.Models
{
    public class StartModel // ToDo: Change to Scene Model 
    {
        private readonly IGameStateMachine _gameStateMachine; 
        private readonly SceneService _sceneService;
        
        public StartModel(IGameStateMachine gameStateMachine, SceneService sceneService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneService = sceneService;
        }

        public void OnNextState()
        {
            // _sceneService
            //     .OnLoadSceneAsync(1);
            _gameStateMachine.EnterAsync<LoaderState>();
        }
        
        public void OnNextState(int scene)
        {
            // _sceneService
            //     .OnLoadSceneAsync(scene);
            
            _gameStateMachine.EnterAsync<LoaderState>();
        }
        
        public void OnNextState(Type state)
        {
            _gameStateMachine.Enter(state);
        }
    }
}