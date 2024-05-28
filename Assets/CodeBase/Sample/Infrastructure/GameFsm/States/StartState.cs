using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Sample.Services.Scene;
using UnityEngine;

namespace Sample.Infrastructure.GameFsm.States
{
    public class StartState : AbstractState, IState
    {
        private readonly SceneService _sceneService;

        public StartState(
            IGameStateMachine gameStateMachine, SceneService sceneService) : base(gameStateMachine)
        {
            _sceneService = sceneService;
        }
        
        public void OnEnter()
        {
            if (!_sceneService.IsCurrentScene(0))
            {
                _sceneService
                    .OnLoadSceneAsync(0);
                Debug.Log("Open Scene");
            }
            Debug.Log("first state");
        }

        public override void OnExit()
        {
            // GameFsm?.Enter<LoaderState>();
        }
    }
}