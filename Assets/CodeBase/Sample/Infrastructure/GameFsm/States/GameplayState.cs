using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Sample.Services.Scene;
using UnityEngine;

namespace Sample.Infrastructure.GameFsm.States
{
    public class GameplayState : AbstractState, IState
    {
        private readonly SceneService _sceneService;
        
        public GameplayState(IGameStateMachine gameStateMachine, SceneService sceneService) : base(gameStateMachine)
        {
            _sceneService = sceneService;
        }

        public void OnEnter()
        {
            Debug.Log("Enter Game");
            _sceneService
                .OnLoadSceneAsync(1);
        }

        public override void OnExit() { }
    }
}