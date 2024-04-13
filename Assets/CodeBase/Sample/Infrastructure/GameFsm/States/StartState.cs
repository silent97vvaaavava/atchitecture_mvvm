using System.Collections;
using Core.Infrastructure.GameFsm;
using Core.Infrastructure.GameFsm.States;
using Sample.Services.Scene;
using UnityEngine;

namespace Sample.Infrastructure.GameFsm.States
{
    public class StartState : AbstractState
    {
        private readonly SceneService _sceneService;

        public StartState(
            IGameFsm gameFsm, SceneService sceneService) : base(gameFsm)
        {
            _sceneService = sceneService;
        }
        
        public override void Enter()
        {
            if (!_sceneService.IsCurrentScene(0))
            {
                _sceneService
                    .OnLoadSceneAsync(0);
                Debug.Log("Open Scene");
            }
            Debug.Log("first state");
        }

        public override IEnumerator Execute()
        {
            yield return null;
        }

        public override void Exit()
        {
            // GameFsm?.Enter<LoaderState>();
        }
    }
}